using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EatlistApi.Models;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        #region "Declaration"
        //private static readonly ApplicationDbContext _dish = new ApplicationDbContext();
        //private readonly DishesRepository _dishRepo = new DishesRepository(_dish);
        //readonly ILogger<DishesController> _log;
        private Dishes _Dishes = new Dishes();
        public readonly DishesRepository _dishRepo = new DishesRepository();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();



        public DishesController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        #endregion

        // GET: api/<controller>
        [HttpGet, Route("get")]
        public IActionResult Get(int ID)
        {
            try
            {
                return Ok(_dishRepo.Get(ID));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }
            
        }

        // GET api/<controller>/5
        [HttpGet, Route("user")]
        public async  Task<IActionResult> Get()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_dishRepo.GetDishesByUserID(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }
            
        }

        [HttpGet, Route("user/{restaurantID}")]
        public IActionResult Get(string restaurantID)
        {
            try
            {
                return Ok(_dishRepo.GetDishesByUserID(restaurantID));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }
 
        }

        // GET api/<controller>/5
        [HttpPost, Route("create")]
        public async  Task<IActionResult> Post([FromBody]Dish model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ApplicationUser userId = await GetCurrentUserAsync();

                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                _Dishes.DateCreated = DateTime.UtcNow;
                _Dishes.RestaurantID = userId.Id;// model.RestaurantID;
                var result = _dishRepo.Insert(_Dishes);
                if (result == null)
                {
                    return StatusCode(500,"Not Saved Successfully");
                }
                foreach(Media md in model.Media)
                {
                    DishMedia media = new DishMedia();

                    media.DishID = result.DishesID;
                    media.Url = md.Url;
                    media.Type = md.Type.ToString();
                    var ret=_dishRepo.MediaInsert(media);
                    if (ret.Count < 1){ throw new InvalidOperationException(); }
                }
                return Ok(_dishRepo.GetDishMedia(result.DishesID));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Source + " : " + ex.Message);
                return StatusCode(500, "Error,Creating Record");
            }
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateDish([FromBody]DishUpd model)
        { 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ApplicationUser userId = await GetCurrentUserAsync();

                if (_dishRepo.GetMedia(model.DishID).Count>0 && !_dishRepo.DeleteMedia(model.DishID))
                {
                    return StatusCode(500,"Media Not Deleted");
                }
                //DishMedia media =  new DishMedia();
                _Dishes= _dishRepo.Get(model.DishID);
                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                //_Dishes.DateCreated = DateTime.UtcNow;
                _Dishes.RestaurantID = userId.Id;// model.RestaurantID;

                var result = _dishRepo.Update(_Dishes);
                if (result == null)
                {
                    return StatusCode(500, "Not Saved Successfully");
                }
                foreach (Media md in model.Media)
                {
                    DishMedia media = new DishMedia();
                    media.DishID = result.DishesID;
                    media.Url = md.Url;
                    media.Type = md.Type.ToString();
                    var ret = _dishRepo.MediaInsert(media);
                    if (ret.Count < 1) { throw new InvalidOperationException(); }
                }
                return Ok(_dishRepo.GetDishMedia(result.DishesID));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.StackTrace);
                return StatusCode(500);
            }
        }        
    }
}
