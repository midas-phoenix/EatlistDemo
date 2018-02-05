using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;

namespace EatListDataService.Repository
{
    public class PostRepository
    {
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

        #region "Posts"

        public List<DataTables.Posts> GetAll()
        {
            return entities.TblPosts.ToList();
        }

        public DataTables.Posts Get(long id)
        {
            return entities.TblPosts.Find(id);
        }

        public List<DataTables.Posts> GetQueryable(long id)
        {
            return entities.TblPosts.Where(x => x.PostID == id).ToList();
        }


        public void Insert(DataTables.Posts entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblPosts.Add(entity);
            SaveChange();
        }

        public void Update(DataTables.Posts entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            SaveChange();
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
        #endregion

        #region "meta"
        private void SaveChange()
        {
            entities.SaveChanges();
        }
        #endregion

    }
}
