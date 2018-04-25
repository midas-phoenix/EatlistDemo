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

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetPostByID(long id, string CUser)
        {
            try
            {
                return _appContext.TblPosts.Where(p => p.Id == id).Select(
                   p => new
                   {
                       Post = new
                       {
                           p.Caption,
                           p.Id,
                           p.DateCreated,
                           RestaurantID = p.Restaurant != null ? p.Restaurant.Id : null,
                           RestaurantName = p.Restaurant != null ? p.Restaurant.RestaurantName : null,
                           IsRestaurant = p.Restaurant != null ? (bool)p.Restaurant.IsRestaurant : false,
                           CreatedByName = p.CreatedBy.IsRestaurant ? p.CreatedBy.RestaurantName : p.CreatedBy.FullName,
                           CreatedBy = p.CreatedBy.Id,
                           CommentCount = p.Comments.Count(),
                           LikeCount = p.Likes.Count(),
                           Liked = p.Likes.Any(l => l.CreatedBy.Id == CUser)
                       },
                       PostDish = retdish(p.Dish),
                       Media = p.PostsMedia.Select(m => new
                       {
                           m.FileName,
                           m.FileURL,
                           m.FileType
                       }).ToList()
                   }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

       
        public List<PostsMedia> UploadPostMedia(PostsMedia[] medias)
        {
            try
            {
                _appContext.TblPostsMedia.AddRange(medias);
                _appContext.SaveChanges();
                return medias.ToList();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        /**
         * bool allpost: to fetch all viewable post
         * string userid: source of posts
         * string CUser: currently logged in user
         * **/
        public dynamic UserPosts(string userid, bool allpost, string CUser)
        {
            try
            {

                //get list of users whose post to see
                List<string> listusers = new List<string>();
                listusers.Add(userid);
                if (allpost)
                {
                    listusers.AddRange(_appContext.TblFriendship.Where(tf => tf.CreatedBy.Id == userid).Select(x => x.Follower.Id).Distinct().ToList());
                    listusers.AddRange(_appContext.TblFriendship.Where(tf => tf.Follower.Id == userid).Select(x => x.CreatedBy.Id).Distinct().ToList());
                }

                return _appContext.TblPosts.Where(x => listusers.Contains(x.CreatedBy.Id)).Select(
                    p => new
                    {
                        Post = new
                        {
                            p.Caption,
                            p.Id,
                            p.DateCreated,
                            RestaurantID = p.Restaurant != null ? p.Restaurant.Id : null,
                            RestaurantName = p.Restaurant != null ? p.Restaurant.RestaurantName : null,
                            IsRestaurant = p.Restaurant != null ? (bool)p.Restaurant.IsRestaurant : false,
                            CreatedByName = p.CreatedBy.IsRestaurant ? p.CreatedBy.RestaurantName : p.CreatedBy.FullName,
                            CreatedBy = p.CreatedBy.Id,
                            CommentCount = p.Comments.Count(),
                            LikeCount = p.Likes.Count(),
                            Liked = p.Likes.Any(l => l.CreatedBy.Id == CUser)
                        },
                        PostDish = retdish(p.Dish),
                        Media = p.PostsMedia.Select(m => new
                        {
                            m.FileName,
                            m.FileURL,
                            m.FileType
                        })
                    }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic retdish(Dishes dish)
        {
            if (dish != null)
                return new { dish.Id, dish.Name };
            else
                return new { };
        }
    }
}
