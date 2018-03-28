using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatListDataService.DataBase;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatlistApi.Controllers
{
    //[Produces("application/json")]
    [Authorize()]
    [Route("api/Utils")]
    public class UtilsController : Controller
    {
        public ILogger<dynamic> _log;
        public readonly UtilRepository _utilRepo = new UtilRepository();
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();


        public UtilsController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: api/<controller>
        /// <summary>
        /// searches the db for text
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("search/{word}")]
        public async Task<ActionResult> GetViewable(string word)
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_utilRepo.Search(word));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500);
            }

        }

    }
}