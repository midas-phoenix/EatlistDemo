using EatlistApi.ViewsModel;
using EatlistDAL.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.Hubs
{
    public class UserInMemory
    {
        private ConcurrentDictionary<string, UserInfo> _onlineUser { get; set; } = new ConcurrentDictionary<string, UserInfo>();

        public bool AddUpdate(ApplicationUser user, string connectionId)
        {
            var userAlreadyExists = _onlineUser.ContainsKey(user.UserName);

            var userInfo = new UserInfo
            {
                UserName = user.UserName,
                ConnectionId = connectionId,
                Email = user.Email,
                FullName = user.FullName,
                IsRestaurant = user.IsRestaurant,
                Profilepic = user.profilepic,
                UserId = user.Id,
                RestaurantName = user.RestaurantName
            };

            _onlineUser.AddOrUpdate(user.UserName, userInfo, (key, value) => userInfo);

            return userAlreadyExists;
        }

        public void Remove(string name)
        {
            UserInfo userInfo;
            _onlineUser.TryRemove(name, out userInfo);
        }

        public IEnumerable<UserInfo> GetAllUsersExceptThis(string username)
        {
            return _onlineUser.Values.Where(item => item.UserName != username);
        }

        public UserInfo GetUserInfo(string username)
        {
            UserInfo user;
            _onlineUser.TryGetValue(username, out user);
            return user;
        }
    }
}
