using EatListDataService.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;


namespace EatListDataService.Repository
{
    public class ChatRepository:BaseRepository
    {
        #region "Declarations and Constructors"
        //private readonly ApplicationDbContext entities;
        //readonly ILogger<ChatRepository> _log;
       // ApplicationDbContext entities;

        //public ChatRepository(ILogger<ChatRepository> log)
        //{
        //    _log = log;
        //}
        ////private List<Posts> entities;
        //string errorMessage = string.Empty;

        //public ChatRepository(ApplicationDbContext context)
        //{
        //    //this.context = context;
        //    entities = context;
        //}

        //public ChatRepository()
        //{
        //}
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

        //public object Insert(Models.ChatMessages chatMessage)
        //{
        //    throw new NotImplementedException();
        //}

        //public object Insert(global::EatlistApi.Models.ChatMessages chatMessage)
        //{
        //    throw new NotImplementedException();
        //}

        //public object Insert(global::EatlistApi.Models.ChatMessages chatMessage)
        //{
        //    throw new NotImplementedException();
        //}

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

        public dynamic fetchChatMessage(string UserID, string MessageToID)
        {
            try
            {
                using (entities = new ApplicationDbContext())
                {
                    var provider = entities.ChatMessages.Where(p => p.CreatedBy == UserID && p.MessageToID == MessageToID || p.MessageToID == UserID && p.CreatedBy == UserID)
                                                   .OrderBy(m => m.DateCreated).ToList();
                    return provider;
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + " : " + ex.StackTrace);
                return null;
            }
            //return new string[] { "value1", "value2" };
        }

        #endregion

       

    }
}

    

