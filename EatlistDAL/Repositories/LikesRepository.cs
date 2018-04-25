using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class LikesRepository : Repository<Likes>, ILikesRepository
    {
        public LikesRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic FetchLikes(long PostID)
        {
            try
            {
                return _appContext.TblLikes.Where(l => l.Post.Id == PostID).Select(x => new {
                    x.Post.Id,
                    x.CreatedBy,
                    x.DateCreated,
                    CreatedByName = !Convert.ToBoolean(x.CreatedBy.IsRestaurant) ? x.CreatedBy.RestaurantName : x.CreatedBy.FullName
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
        
        public bool LikeExist(int PostID, string UserID)
        {
            try
            {
                return _appContext.TblLikes.Any(l => l.Post.Id == PostID && l.CreatedBy.Id == UserID);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public Likes UserPostLike(int PostID, string UserID)
        {
            return _appContext.TblLikes.Single(x => x.Post.Id == PostID && x.CreatedBy.Id==UserID);
        }
    }

}
