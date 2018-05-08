using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatlistDAL.Repositories
{
    public class ChatMessagesRepository : Repository<ChatMessages>, IChatMessagesRepository
    {
        public ChatMessagesRepository(DbContext context, Microsoft.Extensions.Logging.ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic FetchChatHistory(string UserID, string MessageToID)
        {
            try
            {
                return _appContext.ChatMessages.Where(c => (c.CreatedBy.Id == UserID && c.Recipient.Id == MessageToID) || (c.CreatedBy.Id == MessageToID && c.Recipient.Id == UserID))
                    .Select(x => new
                    {
                        MessageID = x.Id,
                        x.Message,
                        x.DateCreated,
                        CreatedBy = x.CreatedBy.Id,
                        CreatedByName = x.CreatedBy.IsRestaurant ? x.CreatedBy.RestaurantName : x.CreatedBy.FullName,
                        x.CreatedBy.profilepic,
                        Receiver = x.Recipient.Id,
                        ReceiverName = x.Recipient.IsRestaurant ? x.Recipient.RestaurantName : x.Recipient.FullName,
                        RecieverProfilepic = x.Recipient.profilepic
                    });

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic FetchChats(string UserId)
        {
            try
            {
                return _appContext.ChatMessages.Where(c => c.CreatedBy.Id == UserId).GroupBy(r => r.Recipient).Select(x => new
                {
                    ReceiverName = x.FirstOrDefault().Recipient.IsRestaurant ? x.FirstOrDefault().Recipient.RestaurantName : x.FirstOrDefault().Recipient.FullName,
                    Receiver = x.FirstOrDefault().Recipient.Id,
                    RecieverProfilepic = x.FirstOrDefault().Recipient.profilepic,
                    LastMessage = x.OrderByDescending(o => o.DateCreated).FirstOrDefault().Message,
                    x.OrderByDescending(o => o.DateCreated).FirstOrDefault().DateCreated
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
    }

}
