using EatlistDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        dynamic GetUser(string UserID, string me);
        dynamic GetRestaurants(string Id);
    }

    public interface IFriendsRepository: IRepository<Friendship>
    {
        dynamic FetchUserFollowers(string Id);
        dynamic FetchUserFollowing(string Id);
        dynamic FetchMyFollow(string followerId, string UserID);
    }
}
