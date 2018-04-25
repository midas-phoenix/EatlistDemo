using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class NotificationRepository : Repository<Notifications>, INotificationRepository
    {
        public NotificationRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetUserNotification(string Id)
        {
            try
            {
                return _appContext.tblNotification.Where(n => n.Recipient.Id == Id).Select(z => new
                {
                    NotificationID = z.Id,
                    z.Message,
                    z.seen,
                    z.DateCreated,
                    RecipientId = z.Recipient.Id,
                    RecipientName = z.Recipient.IsRestaurant ? z.Recipient.RestaurantName : z.Recipient.FullName
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
