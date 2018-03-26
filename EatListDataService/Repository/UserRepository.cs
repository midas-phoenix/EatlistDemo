using EatListDataService.DataBase;
using EatListDataService.DataTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatListDataService.Repository
{
    public class UserRepository : BaseRepository
    {
        #region "Declarations and Constructors"
        //private readonly ApplicationDbContext entities;
        //readonly ILogger _log;

        //public UserRepository(ILogger log)
        //{
        //    _log = log;
        //}
        //private List<Posts> entities;
        string errorMessage = string.Empty;

        //public UserRepository(ApplicationDbContext context)
        //{
        //    //this.context = context;
        //    entities = context;
        //}
        #endregion

        #region 'Users'
        public async Task<dynamic> GetUser(string UserID, string me)
        {
            try
            {
                return await entities.Users.Where(d => d.Id == UserID).Select(u => new
                {
                    u.Id,
                    u.Bio,
                    u.Email,
                    u.FullName,
                    u.UserName,
                    u.PhoneNumber,
                    u.Address,
                    u.Gender,
                    u.Dob,
                    u.IsRestaurant,
                    u.RestaurantName,
                    u.Doi,
                    u.profilepic,
                    PostCount = entities.TblPosts.Count(p => p.CreatedBy == u.Id),
                    FollowingCount = entities.TblFriendship.Count(f => f.CreatedBy == u.Id),
                    FollowersCount = entities.TblFriendship.Count(fo => fo.FollowerID == u.Id),
                    following = entities.TblFriendship.Any(f => f.CreatedBy == me && f.FollowerID == u.Id),
                    follower = entities.TblFriendship.Any(f => f.CreatedBy == u.Id && f.FollowerID == me)
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + ":" + ex.InnerException + ex.StackTrace);
                return ex;
            }
        }

        public async Task<Upload> UploadProfilePic(Upload upload)
        {
            try
            {
                await entities.tblUploads.AddAsync(upload);
                SaveChange();
                return upload;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                throw ex;
            }
        }

        public async Task<dynamic> FetchRestaurants(string Id)
        {
            try
            {
                if (Id == "0")
                {
                    return entities.Users.Where(x => x.IsRestaurant == true).ToList();
                }
                else
                {
                    return entities.Users.Where(x => x.IsRestaurant == true && x.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + ex.StackTrace);
                return ex; 
            }
        }


        #endregion

        #region "meta"
        //private void SaveChange()
        //{
        //    entities.SaveChanges();
        //}
        #endregion
    }
}
