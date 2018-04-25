using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class UtilsRepository : Repository<Object>, IUtilsRepository
    {
        public UtilsRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic Search(string keyword)
        {
            try
            {
                return new
                {
                    Users = _appContext.Users
                                   .Where(u => u.UserName.Contains(keyword) || u.RestaurantName.Contains(keyword)
                                   || u.Email.Contains(keyword) || u.FullName.Contains(keyword) || u.Id.Contains(keyword))
                                   .Select(x => new { x.Id, x.UserName, x.FullName, x.RestaurantName, x.profilepic, x.IsRestaurant }),
                    dishes = _appContext.TblDishes
                                   .Where(d => d.Name.Contains(keyword) || d.Description.Contains(keyword))
                                   .Select(x => new { DishesID = x.Id, x.Name, x.Description, })
                };
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex;
            }
        }
    }

}
