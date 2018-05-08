using EatlistDAL;
using EatlistDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.Hubs
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize()]
    public class EatlistHub : Hub
    {
        private static UserManager<ApplicationUser> _userManager;
        private UserInMemory _userInfoInMemory;
        private IUnitOfWork _unitofwork;
        readonly ILogger<dynamic> _log;

        public EatlistHub(UserInMemory userInfoInMemory, UserManager<ApplicationUser> userManager, IUnitOfWork unitofwork, ILogger<dynamic> log)
        {
            _log = log;
            _userInfoInMemory = userInfoInMemory;
            _userManager = userManager;
            _unitofwork = unitofwork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(Context.User);

        public override async Task OnConnectedAsync()
        {
            var nuser = await GetCurrentUserAsync();
            if (!_userInfoInMemory.AddUpdate(nuser, Context.ConnectionId))
            {// new user
                var list = _userInfoInMemory.GetAllUsersExceptThis(Context.User.Identity.Name).ToList();
                //await Clients.AllExcept(new List<string> { Context.ConnectionId }).InvokeAsync("NewOnlineUser",_userInfoInMemory.GetUserInfo(Context.User.Identity.Name));
            }
            await base.OnConnectedAsync();
            return;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _userInfoInMemory.Remove(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Searchfriends(string userbit)
        {
            try
            {
                Con
                var friends = _unitofwork.Utils.FindFriends(userbit, _userInfoInMemory.GetUserInfo(Context.User.Identity.Name).UserId);
                await Clients.Caller.SendCoreAsync("FriendSearch", friends);
                    //.SendAsync("FriendSearch", friends);
                return;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                throw ex;
            }
        }

        public async Task SendDirectMessageAsync(EatlistApi.Models.ChatMessages message, string targetUserName)
        {
            try
            {
                ApplicationUser userid = await GetCurrentUserAsync();
                ChatMessages _chatMessage = new ChatMessages();
                _chatMessage.CreatedBy = userid;
                _chatMessage.DateCreated = DateTime.UtcNow;
                _chatMessage.Recipient = await _userManager.FindByIdAsync(message.MessageToID);
                _chatMessage.Message = message.Message;

                var result = _unitofwork.ChatMessages.Add(_chatMessage);
                var userInfoSender = _userInfoInMemory.GetUserInfo(Context.User.Identity.Name);
                var userInfoReciever = _userInfoInMemory.GetUserInfo(targetUserName);
                if (userInfoReciever != null)
                    await Clients.Client(userInfoReciever.ConnectionId).SendAsync("SendDM", message, userInfoSender);
                else
                {//trigger notification
                }

            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ex.StackTrace);
            }

            return;
        }
    }
}
