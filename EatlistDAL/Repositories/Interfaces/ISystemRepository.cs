using System;
using System.Collections.Generic;
using System.Text;
using EatlistDAL.Models;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface INotificationRepository: IRepository<Notifications>
    {
       dynamic GetUserNotification(string Id);
    }

    public interface IUtilsRepository: IRepository<Object> {
        dynamic Search(string keyword);
        dynamic FindFriends(string username, string UserId);
    }

    public interface IChatMessagesRepository: IRepository<ChatMessages> {
        dynamic FetchChatHistory(string UserID, string MessageToID);
        dynamic FetchChats(string UserId);
    }
}
