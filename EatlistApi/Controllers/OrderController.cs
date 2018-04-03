using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using EatlistApi.Models;
using EatlistApi.ViewsModel;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatlistApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private Orders _orders =new Orders();
        private OrderRepository _orderRepo = new OrderRepository();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();

        public OrderController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
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

                _orders.CreatedBy =  userId.Id;
                //_orders.CreatedBy = "fgdfgjhhhtdhhgdsefghgjhjfgtdgrd";// userId.Id;
                _orders.DeliveryLocation = model.DeliveryLocation;
                _orders.DateCreated = DateTime.UtcNow;
                _orders.ResturantID = model.ResturantID;
                _orders.Status = new OrderStatus[0].ToString();// model.;
                var result = _orderRepo.Insert(_orders);
                if (result == null)
                {
                    return StatusCode(500, "Not Saved Successfully");
                }
                foreach (EatlistApi.ViewsModel.OrderDish md in model.dishes)
                {
                    EatListDataService.DataTables.OrderDish dish = new EatListDataService.DataTables.OrderDish();

                    dish.Description = md.Description;
                    dish.DishID = md.DishID;
                    dish.OrderID = md.OrderID;
                    var ret = _orderRepo.DishInsert(dish);
                    if (ret.Count < 1) { throw new InvalidOperationException(); }
                }
                //return the list of orders made by user
                return Ok(_orderRepo.GetAllByUserID(result.CreatedBy));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.StackTrace);
                return StatusCode(500, "Error,Creating Record");
            }
        }


        [HttpGet, Route("user")]
        public IActionResult Get(string UserID)
        {
            try
            {
                return Ok(_orderRepo.GetAllByUserID(UserID));
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
                return Ok(_orderRepo.GetAllResturantID(restaurantID));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}