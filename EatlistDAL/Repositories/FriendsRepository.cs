using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class FriendsRepository : Repository<Friendship>, IFriendsRepository
    {
        public FriendsRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic FetchanyF(string Id)
        {
            try
            {
                return _appContext.TblFriendship.Where(f => f.CreatedBy.Id == Id || f.Follower.Id == Id)
                     .Select(x => new
                     {
                         UserId = x.CreatedBy.Id == Id ? x.Follower.Id : x.CreatedBy.Id,
                         UserName = x.CreatedBy.Id == Id ? x.Follower.UserName : x.CreatedBy.UserName,
                         Email = x.CreatedBy.Id == Id ? x.Follower.Email : x.CreatedBy.Email,
                         Name = x.CreatedBy.Id == Id ? x.Follower.FullName : x.CreatedBy.FullName,
                         IsRestaurant = x.CreatedBy.Id == Id ? x.Follower.IsRestaurant : x.CreatedBy.IsRestaurant,
                         RestaurantName = x.CreatedBy.Id == Id ? x.Follower.RestaurantName : x.CreatedBy.RestaurantName,
                         ProfilePic = x.CreatedBy.Id == Id ? x.Follower.profilepic : x.CreatedBy.profilepic
                     }).Distinct(); 
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic FetchMyFollow(string followerId, string UserID)
        {
            try
            {
                return _appContext.TblFriendship.Where(f => f.CreatedBy.Id == UserID && f.Follower.Id == followerId).Select(x => new
                {
                    x.Id,
                    x.Follower,
                    x.CreatedBy,
                    x.DateCreated
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic FetchUserFollowers(string Id)
        {
            try
            {
                return _appContext.TblFriendship.Where(x => x.Follower.Id == Id)
                    .Select(x => new
                    {
                        FriendshipID = x.Id,
                        FollowerID = x.Follower.Id,
                        CreatedBy = x.CreatedBy.Id,
                        x.DateCreated,
                        FollowerName = x.Follower.IsRestaurant ? x.Follower.RestaurantName : x.Follower.FullName,
                        CreatedByname = x.CreatedBy.IsRestaurant ? x.CreatedBy.RestaurantName : x.CreatedBy.FullName,
                        x.CreatedBy.profilepic,
                        FollowerProfilepic = x.Follower.profilepic
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic FetchUserFollowing(string Id)
        {
            try
            {
                return _appContext.TblFriendship.Where(x => x.CreatedBy.Id == Id)
                                        .Select(x => new
                                        {
                                            FriendshipID = x.Id,
                                            FollowerID = x.Follower.Id,
                                            x.CreatedBy,
                                            x.DateCreated,
                                            FollowerName = x.Follower.IsRestaurant ? x.Follower.RestaurantName : x.Follower.FullName,
                                            CreatedByname = x.CreatedBy.IsRestaurant ? x.CreatedBy.RestaurantName : x.CreatedBy.FullName
                                        }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
    }
}
