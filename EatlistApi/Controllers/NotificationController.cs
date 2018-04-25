using System.Threading.Tasks;
using EatlistApi.ViewsModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Authorization;
using EatlistDAL.Models;
using EatlistDAL;

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Produces("application/json")]
    [Route("api/Notification")]
    public class NotificationController : Controller
    {
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;
        private IUnitOfWork _unitofwork;
        public NotificationController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitofwork)
        {
            _log = log;
            _userManager = userManager;
            _unitofwork = unitofwork;
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // POST: api/Notification
        //[HttpPost, Route("Create")]
        //public async Task<IActionResult> Create([FromBody]Notification model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        //string CreatedBy = "";`
        //        ApplicationUser userid = await GetCurrentUserAsync();
        //        _notif.Recipient = "hfbvyuyfbreufbu"; //model.Recipient;
        //        _notif.CreatedBy = "afdfdgjkiuouoi"; //userid.Id;
        //        _notif.Message = model.Message;
        //        _notif.DateCreated = DateTime.UtcNow;
        //        //EatlistApi.ViewsModel.Notification notific = new EatlistApi.ViewsModel.Notification();
        //        var result = _notifRepo.GetUserNotification("hfbvyuyfbreufbu", model.CreatedBy);

        //        if (result == null)
        //        {
        //            return StatusCode(500, "Not Saved Successfully");
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogError(ex.Message + ex.StackTrace);
        //        return StatusCode(500, new { message = ex.Message });
        //    }

        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet, Route("fetchNotification")]
        public async Task<IActionResult> fetchNotification()
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();
                return Ok(_unitofwork.Notification.GetUserNotification(userid.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = "an error occurred"});
            }
        }

        [HttpPost, Route("SeenNotification/Id")]
        public async Task<IActionResult> UpdateNotification(int Id)
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();
                var notf = _unitofwork.Notification.Get(Id);
                notf.seen = true;
                _unitofwork.Notification.Update(notf);
                return Ok(_unitofwork.Notification.GetUserNotification(userid.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = "an error occurred" });
            }
        }
    }
}
