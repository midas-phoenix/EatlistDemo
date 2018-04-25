using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using EatlistApi.Models;
using EatlistApi.ViewsModel;
using EatlistDAL;
using EatlistDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        public ILogger<dynamic> _log;
        private IUnitOfWork _unitofwork;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();

        public OrderController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitofwork)
        {
            _log = log;
            _userManager = userManager;
            _unitofwork = unitofwork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody]Order model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ApplicationUser userId = await GetCurrentUserAsync();
                Orders _orders = new Orders();
                _orders.CreatedBy = userId;
                _orders.DeliveryLocation = model.DeliveryLocation;
                _orders.DateCreated = DateTime.UtcNow;
                _orders.Restaurant = await _userManager.FindByIdAsync(model.ResturantID);
                _orders.Status = new OrderStatus[0].ToString();// model.;
                var result = _unitofwork.Order.Add(_orders);
                if (result == null)
                {
                    return StatusCode(500, "Not Saved Successfully");
                }

                List<EatlistDAL.Models.OrderDish> odishes = new List<EatlistDAL.Models.OrderDish>();
                foreach (EatlistApi.ViewsModel.OrderDish md in model.dishes)
                {
                    EatlistDAL.Models.OrderDish dish = new EatlistDAL.Models.OrderDish();

                    dish.Description = md.Description;
                    dish.Dish = _unitofwork.Dishes.Get(md.DishID);
                    dish.Order = result;
                    odishes.Add(dish);
                }
                    var ret = _unitofwork.OrderDish.AddRange(odishes);
                    //if (ret.Count < 1) { throw new InvalidOperationException(); }
                //return the list of orders made by user
                return Ok(_unitofwork.Order.GetAllByUserID(result.CreatedBy.Id, userId.IsRestaurant));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.StackTrace);
                return StatusCode(500, "Error,Creating Record");
            }
        }


        [HttpGet, Route("user")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_unitofwork.Order.GetAllByUserID(userId.Id, userId.IsRestaurant));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpGet, Route("user/{restaurantID}")]
        public IActionResult GetResturantID(string restaurantID)
        {
            try
            {
                return Ok(_unitofwork.Order.GetAllByUserID(restaurantID, true));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}