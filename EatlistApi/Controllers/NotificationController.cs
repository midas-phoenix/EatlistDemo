using System.Threading.Tasks;
using EatlistApi.ViewsModel;
using EatListDataService.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EatListDataService.Repository;
using System;

namespace EatlistApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
        private Notification _notif = new Notification();
        private NotificationRepository _notifRepo = new NotificationRepository();
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();
        public NotificationController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // POST: api/Notification
        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create([FromBody]Notification model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //string CreatedBy = "";`
                ApplicationUser userid = await GetCurrentUserAsync();
                _notif.Recipient = "hfbvyuyfbreufbu"; //model.Recipient;
                _notif.CreatedBy = "afdfdgjkiuouoi"; //userid.Id;
                _notif.Message = model.Message;
                _notif.DateCreated = DateTime.UtcNow;
                //EatlistApi.ViewsModel.Notification notific = new EatlistApi.ViewsModel.Notification();
                var result = _notifRepo.GetUserNotification("hfbvyuyfbreufbu", model.CreatedBy);

                if (result == null)
                {
                    return StatusCode(500, "Not Saved Successfully");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = ex.Message });
            }

        }

        //// PUT: api/Notification/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        //[HttpPost, Route("fetchNotification")]
        //public async Task<IActionResult> fetchNotification()
        //{
        //    ApplicationUser userid = await GetCurrentUserAsync();
        //    return Ok(_notifRepo.fetchAllNotification(userid.Id));
        //}
    }
}
