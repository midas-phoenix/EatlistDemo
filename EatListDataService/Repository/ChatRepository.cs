using EatListDataService.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace EatListDataService.Repository
{
    public class ChatRepository
    {
        #region "Declarations and Constructors"
        private readonly ApplicationDbContext entities;
        readonly ILogger<ChatRepository> _log;

        public ChatRepository(ILogger<ChatRepository> log)
        {
            _log = log;
        }
        //private List<Posts> entities;
        string errorMessage = string.Empty;

        public ChatRepository(ApplicationDbContext context)
        {
            //this.context = context;
            entities = context;
        }
        #endregion

        #region "Chats"

        public List<DataTables.ChatMessages> GetAll()
        {
            return entities.ChatMessages.ToList();
        }

        public DataTables.ChatMessages Get(long id)
        {
            return entities.ChatMessages.Find(id);
        }

        public List<DataTables.ChatMessages> GetQueryable(long id)
        {
            return entities.ChatMessages.Where(x => x.ChatMessageID == id).ToList();
        }


        public DataTables.ChatMessages Insert(DataTables.ChatMessages entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.ChatMessages.Add(entity);
            SaveChange();
            return entity;
        }

        public DataTables.ChatMessages Update(DataTables.ChatMessages entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.ChatMessages.Update(entity);
            SaveChange();
            return entity;
        }

        public void Delete(DataTables.ChatMessages entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.ChatMessages.Remove(entity);
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

    

