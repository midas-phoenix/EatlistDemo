using System;
using System.Collections.Generic;
using EatlistApi.Models;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : BaseController
    {
        #region "Declaration"
        //private static readonly ApplicationDbContext _dish = new ApplicationDbContext();
        //private readonly DishesRepository _dishRepo = new DishesRepository(_dish);
        //readonly ILogger<DishesController> _log;
        private Dishes _Dishes = new Dishes();
        public readonly DishesRepository _dishRepo = new DishesRepository();
        //UserID will be changed
        //string UserID = "03503819-15ce-489c-946e-ff86a5324189";


        public DishesController(ILogger<DishesController> log)
        {
            _log = log;
        }
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_dishRepo.GetDishesByUserID(UserID));
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
        public IActionResult Post([FromBody]Dish model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                _Dishes.DateCreated = DateTime.UtcNow;
                _Dishes.RestaurantID = UserID;// model.RestaurantID;
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
        public IActionResult UpdateDish([FromBody]DishUpd model)
        { 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(_dishRepo.GetMedia(model.DishID).Count>0 && !_dishRepo.DeleteMedia(model.DishID))
                {
                    return StatusCode(500,"Media Not Deleted");
                }
                //DishMedia media =  new DishMedia();
                _Dishes= _dishRepo.Get(model.DishID);
                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                //_Dishes.DateCreated = DateTime.UtcNow;
                _Dishes.RestaurantID = UserID;// model.RestaurantID;

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
