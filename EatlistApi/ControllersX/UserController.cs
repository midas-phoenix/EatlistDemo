using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatlistApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        //private  ApplicationUser _user = new ApplicationUser();
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private UserManager<ApplicationUser> _userManager;
        readonly ILogger<UserController> _log;

        //class constructor
        public UserController(UserManager<ApplicationUser> userManager, ILogger<UserController> log)
        {
            _userManager = userManager;
            _log = log;
        }

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private Upload _upload;
        private Restaurant _restaurant;
        string UserID = "03503819-15ce-489c-946e-ff86a5324189";

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //[Route("Upload")]
        [HttpPost]
        [HttpPost, Route("profileX")]
        public async Task<IActionResult> Uploads(ProfileUpload upload)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userName = identity.Name;
            //upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());//?? identity.GetUserName();
            var userid = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                //= new Upload();

                _upload.IsProfile = true;
                _upload.UserID = userid.Id;// Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
                _upload.FileUrl = upload.FileUrl;

                await _context.tblUploads.AddAsync(_upload);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<controller>
        // [Route("Post")]
        [HttpPost, Route("profileUp")]
        public async Task<IActionResult> Post(ProfileUpload upload)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userid = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                _upload.IsProfile = true;
                _upload.UserID = userid.Id;// Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
                _upload.FileUrl = upload.FileUrl;

                var setFalse=_context.tblUploads.Where(x=>x.UserID== userid.Id).AsEnumerable().All(x=> { x.IsProfile = false;return true; });

                var ret = setFalse ? _context.SaveChanges() : -1;
                if (ret>0)
                {
                    return StatusCode(500);
                }
                await _context.tblUploads.AddAsync(_upload);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost, Route("makeRestaurant")]
        [Authorize()]
        public async Task<IActionResult> Post([FromBody]Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {



                    var identity = (ClaimsIdentity)User.Identity;
                    var userid = await _userManager.GetUserAsync(User);
                    _log.LogInformation("RestaurantName : " + userid.RestaurantName);
                    _log.LogInformation("IsRestaurant : " + userid.IsRestaurant);
                    //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                    //var ctx = store.Context;
                    //var manager = new UserManager<ApplicationUser>(store);
                    userid.IsRestaurant = true;
                    userid.RestaurantName = restaurant.RestaurantName;
                    await _userManager.UpdateAsync(userid);

                    //await _context.tblUploads.AddAsync(_upload);
                    //_userManager.UpdateAsync()
                    //await _context.SaveChangesAsync();
                    //await ctx.SaveChangesAsync();
                    return Ok(userid);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500,new { message=ex.Message});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("getRestaurant")]
        [Authorize()]
        public async Task<IActionResult> GetRestaurant(string id)
        {
            try
            {
                if (id == "0")
                {
                    return Ok(_context.Users.Where(x => x.IsRestaurant == true).ToList());
                }
                else
                {
                    return Ok(_context.Users.Where(x => x.IsRestaurant == true && x.Id == id).ToList());
                }

                //return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }






        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
