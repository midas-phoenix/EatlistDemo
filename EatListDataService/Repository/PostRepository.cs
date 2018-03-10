using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;

namespace EatListDataService.Repository
{
    public class Messaging
    {
        public string Message { get; set; }
        public string Source { get; set; }
    }
    public class PostRepository:BaseRepository
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

        public List<DataTables.Posts> GetAllByUserID(string UserID)
        {
            return entities.TblPosts.Where(x => x.CreatedBy == UserID).ToList();
        }

        public DataTables.Posts Get(long id)
        {
            return entities.TblPosts.Find(id);
        }

        public List<DataTables.Posts> GetViewableForUser(string UserID)
        {
            var viewablePosts = (from users in entities.Users
                                  join friendsFolld in entities.TblFriendship on users.Id equals friendsFolld.CreatedBy
                                  join friendsFollg in entities.TblFriendship on users.Id equals friendsFollg.FollowerID
                                  join posts in entities.TblPosts on users.Id equals posts.CreatedBy 
                                  where users.Id==UserID
                                 select new DataTables.Posts
                                  {
                                      PostID = posts.PostID,
                                      //FileURL = posts.FileURL,
                                      //FileType = posts.FileType,
                                      CreatedBy = posts.CreatedBy
                                  })
                                .ToList();
            return viewablePosts;
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
            if (entity == null)
            {
                throw
                     new ArgumentNullException("entity");
            }
            entities.TblPostsMedia.Add(entity);
            SaveChange();
            return entity;
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
                //_log.LogInformation("Abeg joor");
                //_log.LogInformation(ex.Message + " : " + ex.InnerException);

                return ex;
            }

        }

        public dynamic FetchComments(int PostID)
        {
            try
            {
                var Comments = entities.TblCommennts.Where(x => x.PostID == PostID).ToList();
                if (Comments.Count > 0)
                {
                    return Comments;
                }

                return "Not Found";
            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                //_log.LogInformation(ex.Message + " : " + ex.InnerException);

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
                //_log.LogInformation("Abeg joor");
                //_log.LogInformation(ex.Message + " : " + ex.InnerException);

                return ex;
            }

        }

        public dynamic FetchLikes(int PostID)
        {
            try
            {
                var Likes = entities.TblLikes.Where(x => x.PostID == PostID).ToList();
                if (Likes.Count > 0)
                {
                    return Likes;
                }
                
                return "Not Found";
            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                //_log.LogInformation(ex.Message + " : " + ex.InnerException);

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

        public dynamic GetAllbyUserID(string UserID)
        {
            //var 
            try
            {
                List<dynamic> result = new List<dynamic>();
                var IDS = entities.TblPosts.Where(x => x.CreatedBy == UserID).Select(x => x.PostID).ToList();
                foreach (int id in IDS) { result.Add(GetPostmedia(id)); }
                return result;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }

        public dynamic GetPostmedia(long id)
        {
            try
            {
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

                var Post = entities.TblPosts.Where(x => x.PostID == id)
                                    .Select(d => new {d.RestaurantID,entities.Users.Where(x=>x.Id==d.RestaurantID).FirstOrDefault().RestaurantName,
                                                      d.Caption,d.CreatedBy,
                                                     createdByname=entities.Users.Where(x => x.Id == d.CreatedBy).FirstOrDefault().FullName})
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
                                    .Select(d => new { d.FileType,d.FileURL }).ToList();

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
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }
    }
}
