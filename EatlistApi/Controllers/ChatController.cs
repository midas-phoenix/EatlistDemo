using System;
using System.Threading.Tasks;
using EatlistDAL;
using EatlistDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatlistApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {

        readonly ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;
        private IUnitOfWork _unitOfwork;

        public ChatController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfwork)
        {
            _log = log;
            _userManager = userManager;
            _unitOfwork = unitOfwork;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet, Route("Chats")]
        public async Task<IActionResult> FetchChatsAsync()
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();
                return Ok(_unitOfwork.ChatMessages.FetchChats(userid.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = "An error occurred" });
            }
        }

        [HttpGet, Route("ChatHistory/{Recipient}")]
        public async Task<IActionResult> ChatHistory(string Recipient)
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();
                return Ok(_unitOfwork.ChatMessages.FetchChatHistory(userid.Id, Recipient));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { message = "An error occurred" });
            }
        }

        // POST: api/Chat
        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create([FromBody]Models.ChatMessages chat)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ApplicationUser userid = await GetCurrentUserAsync();
                ChatMessages _chatMessage = new ChatMessages();
                _chatMessage.CreatedBy = userid;
                //_chatMessage.CreatedBy = "fgdfgjhhhtdhhgdsefghgjhjfgtdgrd"; //userid.Id;
                _chatMessage.DateCreated = DateTime.UtcNow;
                //_chatMessage.MessageSenderID = chat.MessageSenderID;
                _chatMessage.Recipient = await _userManager.FindByIdAsync(chat.MessageToID);
                _chatMessage.Message = chat.Message;

                var result = _unitOfwork.ChatMessages.Add(_chatMessage);
                if (result == null)
                {
                    return StatusCode(500, "Not Successful");
                }
                else
                {
                    return Ok(_unitOfwork.ChatMessages.FetchChatHistory(userid.Id, chat.MessageToID));
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + " : " + ex.StackTrace);
                return null;
            }

            //return "";
        }


    }
}
