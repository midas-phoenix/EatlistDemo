using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EatlistApi.Models;
using EatlistDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private UserManager<EatlistDAL.Models.ApplicationUser> _userManager;
        readonly ILogger<UserController> _log;

        public static IConfiguration Configuration;
        //class constructor
        public UserController(ILogger<UserController> log, UserManager<EatlistDAL.Models.ApplicationUser> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            Configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        private Task<EatlistDAL.Models.ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private Upload _upload;
        //private Restaurant _restaurant;
        //string userId = "03503819-15ce-489c-946e-ff86a5324189";

        // GET api/<controller>/5
        [HttpGet, Route("GetUserInfo")]
        public async Task<IActionResult> Get()
        {
            try
            {
                EatlistDAL.Models.ApplicationUser userId = await GetCurrentUserAsync();
                //return Ok(value: _userRepo.GetUser(userId.Id, userId.Id));
                return Ok(_unitOfWork.Users.GetUser(userId.Id, userId.Id));
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        // GET api/<controller>/5
        [HttpGet, Route("GetUserById/{UserId}")]
        public async Task<IActionResult> Get(string UserId)
        {
            try
            {
                EatlistDAL.Models.ApplicationUser userId = await GetCurrentUserAsync();
                //return Ok(_userRepo.GetUser(UserId, userId.Id));
                return Ok(_unitOfWork.Users.GetUser(UserId, userId.Id));
            }
            catch (Exception ex)
            {

                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        //[Route("Upload")]
        //[HttpPost]
        //[HttpPost, Route("profileX")]
        //public async Task<IActionResult> Uploads(ProfileUpload upload)
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var userName = identity.Name;
        //    //upload.userId = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());//?? identity.GetUserName();
        //    var userId = await _userManager.GetUserAsync(User);

        //    if (ModelState.IsValid)
        //    {
        //        Upload _upload= new Upload();

        //        _upload.IsProfile = true;
        //        _upload.userId = userId.Id;// Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
        //        _upload.FileUrl = upload.FileUrl;

        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        // POST api/<controller>
        // [Route("Post")]
        [HttpPost, Route("profileUp")]
        public async Task<IActionResult> Post(ProfileUpload upload)
        {
            try
            {
                Account acc = new Account(Configuration["my_cloud_name"], Configuration["my_api_key"], Configuration["my_api_secret"]);
                Cloudinary cloudinary = new Cloudinary(acc);
                EatlistDAL.Models.ApplicationUser userId = await GetCurrentUserAsync();

                if (ModelState.IsValid)
                {
                    //Upload _upload = new Upload();
                    //_upload.IsProfile = true;
                    //_upload.UserID = userId.Id;// Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
                    //_upload.FileUrl = upload.FileUrl;
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(upload.FileUrl),
                        Folder = "Eatlist/profilepic/"
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    userId.profilepic = uploadResult.SecureUri.AbsolutePath;
                    userId.profilepicName = uploadResult.PublicId;
                    await _userManager.UpdateAsync(userId);

                    return Ok(_unitOfWork.Users.GetUser(userId.Id, userId.Id));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost, Route("makeRestaurant")]
        public async Task<IActionResult> Post([FromBody]Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EatlistDAL.Models.ApplicationUser userId = await GetCurrentUserAsync();
                    _log.LogInformation("RestaurantName : " + userId.RestaurantName);
                    _log.LogInformation("IsRestaurant : " + userId.IsRestaurant);
                    //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                    //var ctx = store.Context;
                    //var manager = new UserManager<ApplicationUser>(store);
                    userId.IsRestaurant = true;
                    userId.RestaurantName = restaurant.RestaurantName;
                    await _userManager.UpdateAsync(userId);

                    //await _context.tblUploads.AddAsync(_upload);
                    //_userManager.UpdateAsync()
                    //await _context.SaveChangesAsync();
                    //await ctx.SaveChangesAsync();
                    return Ok(userId);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>Gender
        [HttpGet, Route("getRestaurant/{id}")]
        public IActionResult GetRestaurant(string id)
        {
            try
            {
                //return Ok(await _userRepo.FetchRestaurantsAsync(id));
                return Ok(_unitOfWork.Users.GetRestaurants(id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost, Route("UpdateAccount")]
        public async Task<IActionResult> Update([FromBody]UserData userinfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EatlistDAL.Models.ApplicationUser userId = await GetCurrentUserAsync();
                    userId.Email = userinfo.Email;
                    userId.FullName = userinfo.FullName;
                    userId.RestaurantName = userinfo.RestaurantName;
                    userId.Address = userinfo.Address;
                    userId.Bio = userinfo.Bio;
                    userId.Dob = (DateTime)userinfo.Dob;
                    userId.Doi = (DateTime)userinfo.Doi;
                    userId.PhoneNumber = userinfo.PhoneNumber;
                    userId.Gender = userinfo.Gender == 0 ? "Male" : "Female";

                    await _userManager.UpdateAsync(userId);
                    return Ok(_unitOfWork.Users.GetUser(userId.Id, userId.Id));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = "an error occurred" });
            }
        }
    }
}
