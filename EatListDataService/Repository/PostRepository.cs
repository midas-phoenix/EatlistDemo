using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace EatListDataService.Repository
{
    public class Messaging
    {
        public string Message { get; set; }
        public string Source { get; set; }
    }
    public class PostRepository : BaseRepository
    {
        #region "Declarations and Constructors"
        //private readonly ApplicationDbContext entities;
        //readonly ILogger<PostRepository> _log;

        //public PostRepository(ApplicationDbContext context) : base(context)
        //{

        //}

        //public PostRepository(ApplicationDbContext context,ILogger<PostRepository> log):base(context,log)
        //{
        //    _log = log;
        //}
        #endregion

        #region "Posts"

        private static UserManager<ApplicationUser> _userManager;

        public List<DataTables.Posts> GetAllByUserIDX(string UserID)
        {
            return entities.TblPosts.Where(x => x.CreatedBy == UserID).ToList();
        }

        public DataTables.Posts Get(int id)
        {
            return entities.TblPosts.Find(id);
        }

        public dynamic GetViewableForUser(string UserID)
        {
            try
            {

                List<string> viewableID = entities.TblFriendship.Where(x => x.CreatedBy == UserID).Select(x => x.FollowerID).ToList();
                viewableID.Add(UserID);
                viewableID.AddRange(entities.TblFriendship.Where(x => x.FollowerID == UserID).Select(x => x.CreatedBy).ToList());
                List<dynamic> viewablePosts = new List<dynamic>();
                foreach (var user in viewableID.Distinct())
                {
                    foreach (var item in GetAllbyUserID(user, UserID))
                    {
                        viewablePosts.Add(item);
                    }
                }

                //var viewablePosts = 
                return viewablePosts;//.OrderByDescending(p => p.Post.DateCreated);
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return ex;
            }
        }

        public DataTables.Posts Insert(DataTables.Posts entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblPosts.Add(entity);
            SaveChange();
            return entity;
        }

        public DataTables.PostsMedia Insert(DataTables.PostsMedia entity)
        {
            try
            {

                if (entity == null)
                {
                    throw
                         new ArgumentNullException("entity");
                }
                entities.TblPostsMedia.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                throw ex;
            }
        }

        public DataTables.Posts Update(DataTables.Posts entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entities.TblPosts.FindAsync(entity) == null)
            {
                throw new KeyNotFoundException();
            }
            entities.TblPosts.Update(entity);
            SaveChange();
            return entity;
        }

        public void Delete(DataTables.Posts entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblPosts.Remove(entity);
            SaveChange();
        }

        #endregion

        #region "comments"
        public object CommentInsert(DataTables.Comments entity)
        {
            try
            {
                //throw new FormatException("here");
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblCommennts.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);

                return ex;
            }

        }

        public dynamic FetchComments(int PostID)
        {
            try
            {
                var Comments = entities.TblCommennts.Where(x => x.PostID == PostID).Select(c => new
                {
                    c.PostID,
                    c.CommentID,
                    c.Content,
                    c.DateCreated,
                    c.Image,
                    c.CreatedBy,
                    CreatedByName = entities.Users.Where(x => x.Id == c.CreatedBy).FirstOrDefault().FullName
                }).ToList();
                //if (Comments.Count > 0)
                //{
                //    return Comments;
                //}

                return Comments;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return ex;
            }

        }
        #endregion

        #region "likes"
        public object LikeInsert(DataTables.Likes entity)
        {
            try
            {
                //throw new FormatException("here");
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblLikes.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);

                return ex;
            }

        }

        public dynamic FetchLikes(long PostID)
        {
            try
            {
                var Likes = entities.TblLikes.Where(x => x.PostID == PostID).Select(x => new
                {
                    x.LikeID,
                    x.PostID,
                    x.DateCreated,
                    x.CreatedBy,
                    CreatedByName = entities.Users.Where(l => l.Id == x.CreatedBy).FirstOrDefault().FullName
                }).ToList();
                //if (Likes.Count > 0)
                //{
                return Likes;
                //}

                //return "Not Found";
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);

                return ex;
            }

        }
        #endregion

        //#region "meta"
        //private void SaveChange()
        //{
        //    entities.SaveChanges();
        //}
        //#endregion

        public dynamic GetAllbyUserID(string UserID, string CUser)
        {
            //var 
            try
            {
                List<dynamic> result = new List<dynamic>();
                var IDS = entities.TblPosts.Where(x => x.CreatedBy == UserID).Select(x => x.PostID).ToList();
                foreach (int id in IDS) { result.Add(GetPostmedia(id, CUser)); }
                return result;//.OrderByDescending(p => p.Post.DateCreated);
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace + ex.StackTrace);
                return ex;
            }

        }

        public dynamic GetPostmedia(long id, string CUser)
        {
            try
            {
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

                var Post = entities.TblPosts.Where(x => x.PostID == id)
                                    .Select(d => new
                                    {
                                        d.RestaurantID,
                                        entities.Users.Where(x => x.Id == d.RestaurantID).FirstOrDefault().RestaurantName,
                                        d.Caption,
                                        d.CreatedBy,
                                        d.DateCreated,
                                        d.PostID,
                                        createdByname = entities.Users.Where(x => x.Id == d.CreatedBy).FirstOrDefault().FullName,
                                        CommentCount = entities.TblCommennts.Where(x => x.PostID == d.PostID).Count(),
                                        LikeCount = entities.TblLikes.Where(x => x.PostID == d.PostID).Count(),
                                        Liked = entities.TblLikes.Where(x => x.PostID == d.PostID && x.CreatedBy == CUser).Count() > 0 ? true : false
                                    })
                                    .FirstOrDefault();
                var Postdish = (from pst in entities.TblPosts
                                join dsh in entities.TblDishes on pst.DishID equals dsh.DishesID
                                where pst.PostID == id
                                select new
                                {
                                    dsh
                                })
                               .ToList();

                var Media = entities.TblPostsMedia.Where(x => x.PostID == id)
                                    .Select(d => new { d.FileType, d.FileURL }).ToList();

                //res.AddRange("BookingID",Book.BookingID);
                //res.Add(Book.BookingStatus);
                //res.Add(Book.BookingTime);
                //res.Add(Book.DateCreated);
                //res.Add(Book.Description);
                //object vbook = Book.Single()
                res.Add("Post", Post);
                res.Add("Postdish", Postdish);


                res.Add("Media", Media);
                return res;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace + ex.StackTrace);
                return ex;
            }

        }
    }
}
