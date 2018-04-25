using System;
using System.Collections.Generic;
using System.Text;
using EatlistDAL.Repositories;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace EatlistDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        readonly ILogger<dynamic> _log;
        IUserRepository _user;
        IPostRepository _post;
        IDishRepository _dishes;
        IDishMediaRepository _dishmedia;
        ICommentRepository _comment;
        ILikesRepository _likes;
        IBookingRepository _bookings;
        IBookingDishesRepository _bookingdishes;
        IChatMessagesRepository _ChatMessages;
        IEatListRepository _EatList;
        IFriendsRepository _Friends;
        INotificationRepository _Notification; IOrderRepository _Order; IOrderDishRepository _OrderDish; IUtilsRepository _Utils;

        public UnitOfWork(ApplicationDbContext context, ILogger<dynamic> log)
        {
            _context = context;
            _log = log;
        }

        public IUserRepository Users
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context, _log);

                return _user;
            }
        }

        public IPostRepository posts
        {
            get
            {
                if (_post == null)
                    _post = new PostRepository(_context, _log);

                return _post;
            }
        }

        public IDishRepository Dishes
        {
            get
            {
                if (_dishes == null)
                    _dishes = new DishRepository(_context, _log);

                return _dishes;
            }
        }

        public IDishMediaRepository DishMedia
        {
            get
            {
                if (_dishmedia == null)
                    _dishmedia = new DishMediaRepository(_context, _log);

                return _dishmedia;
            }
        }

        // public ICommentRepository Comments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // public ILikesRepository Likes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICommentRepository Comments
        {
            get
            {
                if (_comment == null)
                    _comment = new CommentRepository(_context, _log);

                return _comment;

            }
        }

        public ILikesRepository Likes
        {
            get
            {
                if (_likes == null)
                    _likes = new LikesRepository(_context, _log);

                return _likes;
            }
        }

        public IBookingRepository Bookings
        {
            get
            {
                if (_bookings == null)
                    _bookings = new BookingRepository
                        (_context, _log);
                return _bookings;
            }
        }

        public IBookingDishesRepository Bookingdishes
        {
            get
            {
                if (_bookingdishes == null)
                    _bookingdishes = new BookingDishesRepository
                        (_context, _log);
                return _bookingdishes;
            }
        }

        public IChatMessagesRepository ChatMessages {
            get
            {
                if (_ChatMessages == null)
                    _ChatMessages = new ChatMessagesRepository
                        (_context, _log);
                return _ChatMessages;
            }
        }

        public IEatListRepository EatList {
            get
            {
                if (_EatList == null)
                    _EatList = new EatListRepository
                        (_context, _log);
                return _EatList;
            }
        }

        public IFriendsRepository Friends
        {
            get
            {
                if (_Friends == null)
                    _Friends = new FriendsRepository
                        (_context, _log);
                return _Friends;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_Notification == null)
                    _Notification = new NotificationRepository
                        (_context, _log);
                return _Notification;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_Order == null)
                    _Order = new OrderRepository
                        (_context, _log);
                return _Order;
            }
        }

        public IOrderDishRepository OrderDish {
            get
            {
                if (_OrderDish == null)
                    _OrderDish = new OrderDishRepository
                        (_context, _log);
                return _OrderDish;
            }
        }

        public IUtilsRepository Utils {
            get
            {
                if (_Utils == null)
                    _Utils = new UtilsRepository
                        (_context, _log);
                return _Utils;
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
