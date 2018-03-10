using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatlistApi.Models;
using Microsoft.AspNetCore.Mvc;
using EatListDataService.DataBase;
using EatListDataService.Repository;
using EatListDataService.DataTables;
using Microsoft.Extensions.Logging;
using EatlistApi.ViewsModel;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        #region "Declaration"
        private static readonly ApplicationDbContext _friend = new ApplicationDbContext();
        private readonly FriendsRepository _friendsRepo = new FriendsRepository(_friend);
        readonly ILogger<FriendsController> _log;
        private Friendship _Friends = null;
        //UserID will be changed
        string UserID = "03503819-15ce-489c-946e-ff86a5324189";


        public FriendsController(ILogger<FriendsController> log)
        {
            _log = log;
        }
        #endregion

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<controller>/5
        //[HttpGet, Route("follower/{FollowerID}")]
        //public IActionResult Get(string FollowerID)
        //{

        //    return Ok(_friendsRepo.GetFriendsByFollowerID(FollowerID));
        //}
        // GET: api/<controller>

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost, Route("create")]
        public IActionResult Friends(string FollowerID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prevRelationship = _friendsRepo.FetchMyFollow(FollowerID, UserID);//userID=Createdby,FollowerID=FollowerID,

            if (prevRelationship.GetType() == typeof(EatListError))
            {
                EatListError _error = (EatListError)prevRelationship;
                _log.LogInformation(_error.ErrorMessage.ToString());
                return StatusCode(500);
            }

            else if (prevRelationship.Count > 0)
            {
                foreach (var prev in prevRelationship)
                {
                    _friendsRepo.Delete(prev);
                }
                return Ok();
            }

            _Friends = new Friendship();
            _Friends.FollowerID = FollowerID;
            _Friends.DateCreated = DateTime.UtcNow;
            _Friends.CreatedBy = UserID;

            return Ok(_friendsRepo.Insert(_Friends));

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
