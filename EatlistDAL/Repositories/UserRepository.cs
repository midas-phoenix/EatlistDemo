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
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, Microsoft.Extensions.Logging.ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        private ILogger<dynamic> log => (ILogger<dynamic>)_log;

        public dynamic GetRestaurants(string Id)
        {
            throw new NotImplementedException();
        }

        public dynamic GetUser(string UserID, string me)
        {
            try
            {
                return _appContext.Users.Where(d => d.Id == UserID).Select(u => new
                {
                    u.Id,
                    u.Bio,
                    u.Email,
                    u.FullName,
                    u.UserName,
                    u.PhoneNumber,
                    u.Address,
                    u.Gender,
                    u.Dob,
                    u.IsRestaurant,
                    u.RestaurantName,
                    u.Doi,
                    u.profilepic,
                    PostCount = u.PCreatedBy.Count(),
                    FollowingCount = u.FCreatedBy.Count(f => f.CreatedBy == u.Id),
                    FollowersCount = u.Friends.Count(fo => fo.FollowerID == u.Id),
                    following = u.FCreatedBy.Any(f => f.CreatedBy == me && f.FollowerID == u.Id),
                    follower = u.Friends.Any(f => f.CreatedBy == u.Id && f.FollowerID == me)
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex;
            }
        }
    }
}
