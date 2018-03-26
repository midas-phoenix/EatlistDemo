using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatListDataService.DataTables;

namespace EatListDataService.Repository
{
    public class EatListError
    {
        public string ErrorMessage { get; set; }

        public string StatusCode { get; set; }

        public DateTime ErrorTime { get; set; }
    }
    public class FriendsRepository : BaseRepository
    {
        #region "Declarations"
        //private readonly ApplicationDbContext entities;
        //readonly ILogger<FriendsRepository> _log;

        //public FriendsRepository(ILogger<FriendsRepository> log)
        //{
        //    _log = log;
        //    //entities = context;
        //}
        //public FriendsRepository(ApplicationDbContext context)
        //{
        //    //_log = log;
        //    entities = context;
        //}
        //private List<Posts> entities;
        string errorMessage = string.Empty;
        #endregion

        #region "Friends"
        public dynamic FetchUserFollowers(string UserID)
        {
            try
            {

                return entities.TblFriendship.Where(x => x.FollowerID == UserID)
                    .Select(x => new
                    {
                        x.FriendshipID,
                        x.FollowerID,
                        x.CreatedBy,
                        x.DateCreated,
                        FollowerName = entities.Users.Where(u => u.Id == x.FollowerID).FirstOrDefault().FullName,
                        CreatedByname = entities.Users.Where(c => c.Id == x.CreatedBy).FirstOrDefault().FullName
                    })
                    .ToList();

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
        public dynamic FetchUserFollowing(string UserID)
        {
            try
            {

                return entities.TblFriendship.Where(x => x.CreatedBy == UserID)
                                        .Select(x => new
                                        {
                                            x.FriendshipID,
                                            x.FollowerID,
                                            x.CreatedBy,
                                            x.DateCreated,
                                            FollowerName = entities.Users.Where(u => u.Id == x.FollowerID).FirstOrDefault().FullName,
                                            CreatedByname = entities.Users.Where(c => c.Id == x.CreatedBy).FirstOrDefault().FullName
                                        }).ToList();

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }

        }
        public DataTables.Friendship Insert(DataTables.Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblFriendship.Add(entity);
            SaveChange();
            return entity;
        }


        public dynamic FetchMyFollow(string followerID, string UserID)
        {
            try
            {
                EatListError _EatListError = new EatListError();
                var _frndList = (from friend in entities.TblFriendship
                                 select friend).ToList();
                if (_frndList != null)
                {
                    return _frndList;
                }
                else if (_frndList == null)
                {
                    _EatListError.ErrorMessage = "Query returned Null object";
                    _EatListError.ErrorTime = DateTime.Now;

                }
                return _EatListError;

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }

        }

        //public object FetchMyFollow(string followerID, string userID)
        //{
        //    throw new NotImplementedException();
        //}

        public DataTables.Friendship Update(DataTables.Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblFriendship.Update(entity);
            SaveChange();
            return entity;
        }

        public void Delete(DataTables.Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblFriendship.Remove(entity);
            SaveChange();
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


