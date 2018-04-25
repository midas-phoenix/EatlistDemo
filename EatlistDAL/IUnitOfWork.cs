using EatlistDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }
        IPostRepository posts { get; }
        IDishRepository Dishes { get; }
        IDishMediaRepository DishMedia { get; }
        ICommentRepository Comments { get; }
        ILikesRepository Likes { get; }
        IBookingRepository Bookings { get; }
        IBookingDishesRepository Bookingdishes { get; }
        IChatMessagesRepository ChatMessages { get; }
        IEatListRepository EatList { get; }
        IFriendsRepository Friends { get; }
        INotificationRepository Notification { get; }
        IOrderRepository Order { get; }
        IOrderDishRepository OrderDish { get; }
        IUtilsRepository Utils { get; }

        int SaveChanges();
    }
}
