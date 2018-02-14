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
    public class PostRepository
    {
        #region "Declarations and Constructors"
        private readonly ApplicationDbContext entities;
        readonly ILogger<PostRepository> _log;

        public PostRepository(ILogger<PostRepository> log)
        {
            _log = log;
        }
        //private List<Posts> entities;
        string errorMessage = string.Empty;

        public PostRepository(ApplicationDbContext context)
        {
            //this.context = context;
            entities = context;
        }
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
                                  select new DataTables.Posts
                                  {
                                      PostID = posts.PostID,
                                      FileURL = posts.FileURL,
                                      FileType = posts.FileType,
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

        #region "meta"
        private void SaveChange()
        {
            entities.SaveChanges();
        }
        #endregion

    }
}
