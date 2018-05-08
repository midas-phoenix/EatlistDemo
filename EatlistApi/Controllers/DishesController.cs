using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EatlistApi.Models;
using EatlistDAL;
using EatlistDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        #region "Declaration"
        //private static readonly ApplicationDbContext _dish = new ApplicationDbContext();
        //private readonly DishesRepository _dishRepo = new DishesRepository(_dish);
        //readonly ILogger<DishesController> _log;
        private Dishes _Dishes = new Dishes();
        //public readonly DishesRepository _dishRepo = new DishesRepository();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();
        public static IConfiguration Configuration;
        private IUnitOfWork _unitOfWork;



        public DishesController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            Configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        #endregion

        // GET: api/<controller>
        [HttpGet, Route("get/{ID}")]
        public IActionResult Get(int ID)
        {
            try
            {
                return Ok(_unitOfWork.Dishes.GetDishByID(ID));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }

        // GET api/<controller>/5
        [HttpGet, Route("user")]
        public async Task<IActionResult> Get()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                _log.LogInformation("testing...");
                var res = _unitOfWork.Dishes.GetDishByUserID(userId.Id);
                string user = JsonConvert.SerializeObject(res);
                _log.LogInformation("user:" + user);
                return Ok(res);
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
                return Ok(_unitOfWork.Dishes.GetDishByUserID(restaurantID));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }

        // GET api/<controller>/5
        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]Dish model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Account acc = new Account(Configuration["my_cloud_name"], Configuration["my_api_key"], Configuration["my_api_secret"]);
                Cloudinary cloudinary = new Cloudinary(acc);
                ApplicationUser userId = await GetCurrentUserAsync();

                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                _Dishes.DateCreated = DateTime.UtcNow;
                _Dishes.CreatedBy = userId;// model.RestaurantID;
                var result = _unitOfWork.Dishes.Add(_Dishes);
                if (result == null)
                {
                    return StatusCode(500, "Could not save dish");
                }
                List<DishMedia> dm = new List<DishMedia>();
                foreach (Media md in model.Media)
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(md.Url),
                        Folder = "Eatlist/Dish/"
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    DishMedia media = new DishMedia();
                    media.Dish = result;
                    media.Url = uploadResult.SecureUri.AbsoluteUri;
                    media.FileName = uploadResult.PublicId;
                    media.Type = md.Type.ToString();
                    dm.Add(media);
                }
                List<DishMedia> ret = (List<DishMedia>)_unitOfWork.DishMedia.AddRange(dm);
                if (ret.Count < 1) { throw new InvalidOperationException(); }
                return Ok(_unitOfWork.Dishes.GetDishByUserID(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.StackTrace);
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
                Account acc = new Account(Configuration["my_cloud_name"], Configuration["my_api_key"], Configuration["my_api_secret"]);
                Cloudinary cloudinary = new Cloudinary(acc);
                ApplicationUser userId = await GetCurrentUserAsync();

                var dms = (List<DishMedia>)_unitOfWork.DishMedia.GetMediaByDishID(model.DishID);
                if (dms.Count > 0)
                {
                    bool dmd = _unitOfWork.DishMedia.RemoveRange(dms);

                    if (!dmd)
                    {
                        return StatusCode(500, "Media Not Deleted");
                    }
                }

                //DishMedia media =  new DishMedia();
                _Dishes = _unitOfWork.Dishes.Get(model.DishID);
                _Dishes.Name = model.Name;
                _Dishes.Description = model.Description;
                //_Dishes.DateCreated = DateTime.UtcNow;
                //_Dishes.CreatedBy = userId.Id;// model.RestaurantID;

                var result = _unitOfWork.Dishes.Update(_Dishes);
                if (result == null)
                {
                    return StatusCode(500, "An error occurred while trying to modify this dish");
                }
                List<DishMedia> dm = new List<DishMedia>();
                foreach (Media md in model.Media)
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(md.Url),
                        Folder = "Eatlist/Dish/"
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    DishMedia media = new DishMedia();
                    media.Dish = result;
                    media.Url = uploadResult.SecureUri.AbsoluteUri;
                    media.FileName = uploadResult.PublicId;
                    media.Type = md.Type.ToString();
                    dm.Add(media);
                }
                List<DishMedia> ret = (List<DishMedia>)_unitOfWork.DishMedia.AddRange(dm);
                if (ret.Count < 1) { throw new InvalidOperationException(); }
                return Ok(_unitOfWork.Dishes.GetDishByUserID(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpDelete("{DishId}")]
        public async Task<IActionResult> DeleteDish(int DishId) {
            try
            {

                ApplicationUser userId = await GetCurrentUserAsync();
                var res = _unitOfWork.Dishes.Get(DishId);
                if (res.Equals(null))
                    return BadRequest(new { message = "Dish could not be found"});
                var dd = _unitOfWork.Dishes.Remove(res);
                if (!dd)
                    return BadRequest(new { message = "Error deleting dish" });
                return Ok(_unitOfWork.Dishes.GetDishByUserID(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.StackTrace);
                return StatusCode(500);
            }  
        }
    }
}
