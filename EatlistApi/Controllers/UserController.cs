using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatlistApi.Models;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        //private  ApplicationUser _user = new ApplicationUser();
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private Upload _upload;

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
        public async Task<IActionResult> PostUploads(ProfileUpload upload)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userName = identity.Name;
            upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());//?? identity.GetUserName();
            if (ModelState.IsValid)
            {
                //= new Upload();

                _upload.IsProfile = true;
                _upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
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
        [HttpPost]
        public async Task<IActionResult> Post(ProfileUpload upload)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userName = identity.Name;
            upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());//?? identity.GetUserName();
            if (ModelState.IsValid)
            {
                _upload.IsProfile = true;
                _upload.UserID = Guid.Parse(identity.FindFirst(ClaimTypes.GivenName).ToString());
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
