using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
   public class UtilRepository : BaseRepository
    {
        #region "Utils"
        public Dictionary<string, dynamic> Search(string seachText)
        {
            //var 
            try
            {
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
                var users= entities.Users
                                   .Where(u=> u.UserName.Contains(seachText) || u.RestaurantName.Contains(seachText) 
                                   || u.Email.Contains(seachText) || u.FullName.Contains(seachText) || u.Id.Contains(seachText))
                                   .Select(x=>new { x.Id, x.UserName, x.FullName,x.RestaurantName,x.profilepic,x.IsRestaurant});
                var dishes = entities.TblDishes
                                   .Where(d => d.Name.Contains(seachText) || d.Description.Contains(seachText))
                                   .Select(x => new { x.DishesID, x.Name, x.Description,});
                res.Add("users", users);
                res.Add("dishes", dishes);
                return res;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }
        #endregion

    }
}
