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
    public class CommentRepository : Repository<Comments>, ICommentRepository
    {
        public CommentRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic FetchComment(int PostID)
        {
            try
            {
                return _appContext.TblCommennts.Where(c => c.Post.Id == PostID).Select(n => new
                {
                    CommentID = n.Id,
                    PostID,
                    n.Content,
                    n.DateCreated,
                    n.Image,
                    CreatedBy = n.CreatedBy.Id,
                    CreatedByName = n.CreatedBy.IsRestaurant == true ? n.CreatedBy.RestaurantName : n.CreatedBy.FullName,
                    n.CreatedBy.profilepic
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
