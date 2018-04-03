using EatListDataService.DataBase;
using EatListDataService.DataTables;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
   public class NotificationRepository : BaseRepository
    {
        public dynamic GetUserNotification(string userid, string CreatedBy)
        {
            try
            {
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();

                var notification = entities.tblNotification.Where(x => x.Recipient == userid && x.CreatedBy == CreatedBy)
                                            .Select(d => new { d.Message, d.DateCreated }).ToList();
                return notification;
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + " : " + ex.StackTrace);
                return null;
            }
        }

        //public dynamic fetchAllNotification(string Userid)
        //{
        //    try
        //    {
        //        using (entities = new ApplicationDbContext())
        //        {
        //            var provider = entities.tblNotification.Where(p => p.CreatedBy == Userid  || p.Recipient == Userid )
        //                                           .OrderBy(m => m.DateCreated).ToList();
        //            return provider;
        //        }
        //    }
        //  catch (Exception ex)
        //    {
        //        _log.LogError(ex.Message + " : " + ex.StackTrace);
        //        return null;
        //    }
        //}

        
    }
}
