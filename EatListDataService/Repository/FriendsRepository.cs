using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatListDataService.DataTables;

namespace EatListDataService.Repository
{
    class FriendsRepository
    {
        #region "Declarations"
        private readonly ApplicationDbContext entities;
        readonly ILogger<PostRepository> _log;

        public FriendsRepository(ILogger<PostRepository> log)
        {
            _log = log;
            //entities = context;
        }
        public FriendsRepository(ApplicationDbContext context)
        {
            //_log = log;
            entities = context;
        }
        //private List<Posts> entities;
        string errorMessage = string.Empty;
        #endregion

        #region "Friends"
        public List<Friendship> FetchUserFollowers(string UserID)
        {
            try
            {
           
                return entities.TblFriendship.Where(x => x.FollowerID == UserID).ToList();

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }

        }
        #endregion

        #region "Following"
        public List<Friendship> FetchUserFollowing(string UserID)
        {
            try
            {

                return entities.TblFriendship.Where(x =>x.CreatedBy == UserID).ToList();

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
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
    

