using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EatlistDAL.Repositories
{
    public class PostRepository : Repository<Posts>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public dynamic GetPostmedia(long id, string CUser)
        {
            throw new NotImplementedException();
        }

        public dynamic GetViewableForUser(string UserID)
        {
            throw new NotImplementedException();
        }

        public void NewPost(Posts post, PostsMedia pm)
        {
            throw new NotImplementedException();
        }

        /**
         * bool allpost: to fetch all viewable post
         * 
         * **/
        private dynamic UserPosts(string userid, bool allpost, string CUser)
        {
            //get list of users whose post to see
            List<string> listusers = new List<string>();
            listusers.Add(userid);
            if (allpost)
            {
                listusers.AddRange(_appContext.TblFriendship.Where(tf => tf.CreatedBy == userid).Select(x => x.FollowerID).Distinct().ToList());
                listusers.AddRange(_appContext.TblFriendship.Where(tf => tf.FollowerID == userid).Select(x => x.CreatedBy).Distinct().ToList());
            }

            return _appContext.TblPosts.Where(x => listusers.Contains(x.CreatedBy)).OrderByDescending(d => d.DateCreated).Select(
                p => new
                {
                    Post = new
                    {
                        p.Caption,
                        p.Id,
                        p.RestaurantID,
                        p.Restaurants.RestaurantName,
                        p.Restaurants.IsRestaurant,
                        CreatedByName = !Convert.ToBoolean(p.Restaurants.IsRestaurant) ? p.ApplicationUser.RestaurantName : p.ApplicationUser.FullName,
                        p.CreatedBy,
                        CommentCount = p.Comments.Count(),
                        LikeCount = p.Likes.Count(),
                        Liked = p.Likes.Count(l=>l.CreatedBy==CUser) > 0 ? true : false
                    },
                    PostDish = new { p.Dishes.Id, p.Dishes.Name },
                    Media = p.PostsMedia.Select(m => new
                    {
                        m.FileName,
                        m.FileURL,
                        m.FileType
                    })
                }
                );
        }
    }
}
