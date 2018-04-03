using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatlistApi.Models;
using EatListDataService.DataBase;
using EatListDataService.Repository;
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
        private EatListDataService.DataTables.ChatMessages _chatMessage = new EatListDataService.DataTables.ChatMessages();
        private ChatRepository _chatRepo = new ChatRepository();
        //private readonly ApplicationDbContext entities;
        readonly ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;

        public ChatController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
      
        
        
        // POST: api/Chat
        [HttpPost, Route("Create")]
        public async Task<IActionResult>  Create([FromBody]ChatMessages chat)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ApplicationUser userid = await GetCurrentUserAsync();
                _chatMessage.CreatedBy = userid.Id;
                //_chatMessage.CreatedBy = "fgdfgjhhhtdhhgdsefghgjhjfgtdgrd"; //userid.Id;
                _chatMessage.DateCreated = DateTime.UtcNow;
                //_chatMessage.MessageSenderID = chat.MessageSenderID;
                _chatMessage.MessageToID = chat.MessageToID;
                _chatMessage.Message = chat.Message;

                var result = _chatRepo.Insert(_chatMessage);
                if (result == null)
                {
                    return StatusCode(500, "Not Successful");
                }
                else
                {
                    //_chatRepo.fetchChatMessage(_chatMessage.CreatedBy,_chatMessage.MessageToID);
                    //return Ok(_chatRepo.fetchChatMessage(/*userid.Id*/"fgdfgjhhhtdhhgdsefghgjhjfgtdgrd", chat.MessageToID));
                    return Ok(_chatRepo.fetchChatMessage(userid.Id, chat.MessageToID));
                    //ChatController. fetchChatMessage(userid, MessageToID);
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
