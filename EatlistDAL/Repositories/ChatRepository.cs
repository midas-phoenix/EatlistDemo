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
                        x.CreatedBy,
                        CreatedByName = x.CreatedBy.IsRestaurant ? x.CreatedBy.RestaurantName : x.CreatedBy.FullName,
                        Receiver = x.Recipient.Id,
                        ReceiverName = x.Recipient.IsRestaurant ? x.Recipient.RestaurantName : x.Recipient.FullName
                    });

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw;
            }
        }
    }

}
