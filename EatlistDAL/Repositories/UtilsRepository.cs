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

        public dynamic FindFriends(string username, string userId)
        {
            try
            {
                return _appContext.TblFriendship.Where(f => (f.CreatedBy.Id == userId || f.Follower.Id == userId) && (f.CreatedBy.UserName.Contains(username) || f.CreatedBy.FullName.Contains(username) ||
                f.CreatedBy.RestaurantName.Contains(username) || f.Follower.UserName.Contains(username) || f.Follower.FullName.Contains(username) || f.Follower.RestaurantName.Contains(username)))
                .Select(x => new
                {
                    UserId = x.CreatedBy.Id == userId ? x.Follower.Id : x.CreatedBy.Id,
                    UserName = x.CreatedBy.Id == userId ? x.Follower.UserName : x.CreatedBy.UserName,
                    Email = x.CreatedBy.Id == userId ? x.Follower.Email : x.CreatedBy.Email,
                    Name = x.CreatedBy.Id == userId ? x.Follower.FullName : x.CreatedBy.FullName,
                    IsRestaurant = x.CreatedBy.Id == userId ? x.Follower.IsRestaurant : x.CreatedBy.IsRestaurant,
                    RestaurantName = x.CreatedBy.Id == userId ? x.Follower.RestaurantName : x.CreatedBy.RestaurantName,
                    ProfilePic = x.CreatedBy.Id == userId ? x.Follower.profilepic : x.CreatedBy.profilepic
                }).Distinct();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex;
            }
        }

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
