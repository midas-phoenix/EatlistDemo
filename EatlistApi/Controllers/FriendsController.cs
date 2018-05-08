using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatlistApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EatlistApi.ViewsModel;
using Microsoft.AspNetCore.Identity;
using EatlistDAL.Models;
using EatlistDAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        #region "Declaration"

        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;
        private IUnitOfWork _unitOfWork;


        public FriendsController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        #endregion

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        [HttpGet, Route("Userfollowers/{FollowerID}")]
        public IActionResult Get(string FollowerID)
        {
            try
            {
                return Ok(_unitOfWork.Friends.FetchUserFollowers(FollowerID));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("Myfollowers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_unitOfWork.Friends.FetchUserFollowers(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("Userfollowings/{FollowingID}")]
        public IActionResult ffgGet(string FollowingID)
        {
            try
            {
            return Ok(_unitOfWork.Friends.FetchUserFollowing(FollowingID));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("Myfollowings")]
        public async Task<IActionResult> ffgGet()
        {
            try
            {
            ApplicationUser userId = await GetCurrentUserAsync();
            return Ok(_unitOfWork.Friends.FetchUserFollowing(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("AllffUsers")]
        public async Task<IActionResult> AllffUsers()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_unitOfWork.Friends.FetchanyF(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Friends(string FollowerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser userId = await GetCurrentUserAsync();

            //var prevRelationship = _unitOfWork.Friends.FetchMyFollow(FollowerID, userId.Id);//userID=Createdby,FollowerID=FollowerID,
            var prevRelationship = _unitOfWork.Friends.Find(x => x.Follower.Id == FollowerID && x.CreatedBy.Id == userId.Id).ToList();

            //if (prevRelationship.GetType() == typeof(EatListError))
            //{
            //    EatListError _error = (EatListError)prevRelationship;
            //    _log.LogInformation(_error.ErrorMessage.ToString());
            //    return StatusCode(500);
            //}

            //else 
            if (prevRelationship.Count > 0)
            {
                foreach (var prev in prevRelationship)
                {
                    _unitOfWork.Friends.Remove(prev);
                }
                return Ok(new { status = "user has been unfollowed" });
            }

            Friendship _Friends = new Friendship();
            _Friends.Follower = await _userManager.FindByIdAsync(FollowerID);
            _Friends.DateCreated = DateTime.UtcNow;
            _Friends.CreatedBy = userId;
            var result = _unitOfWork.Friends.Add(_Friends);
            if (result == null)
            {
                return StatusCode(500, "Not Saved Successfully");
            }
            return Ok(new { status = "followed" });

        }



        // PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
