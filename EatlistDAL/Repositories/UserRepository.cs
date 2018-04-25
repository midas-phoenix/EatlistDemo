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
        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetRestaurants(string Id)
        {
            try
            {
                if (Id == "0")
                {
                    return _appContext.Users.Where(x => x.IsRestaurant).Select(u => new
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
                        FollowingCount = u.FCreatedBy.Count(),
                        FollowersCount = u.Followers.Count(),
                        following = u.FCreatedBy.Any(),
                        follower = u.Followers.Any()
                    });
                }
                else
                {
                    return _appContext.Users.Where(x => x.Id == Id).Select(u => new
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
                        FollowingCount = u.FCreatedBy.Count(),
                        FollowersCount = u.Followers.Count(),
                        following = u.FCreatedBy.Any(),
                        follower = u.Followers.Any()
                    }).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex;
            }
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
                    FollowingCount = u.FCreatedBy.Count(),
                    FollowersCount = u.Followers.Count(),
                    following = u.FCreatedBy.Any(),
                    follower = u.Followers.Any()
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex;
            }
        }
    }
}
