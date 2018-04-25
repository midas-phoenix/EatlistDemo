using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EatlistDAL.Repositories
{
    public class BookingRepository : Repository<Bookings>, IBookingRepository
    {
        public BookingRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetAllByUserID(string UserID, bool IsRestaurant)
        {
            try
            {
                if (IsRestaurant)
                {
                    return _appContext.TblBookings.Where(b => b.Restaurant.Id == UserID).Select(x => new
                    {
                        Book = new
                        {
                            BookingID = x.Id,
                            x.BookingTime,
                            x.TableSize,
                            x.DateCreated,
                            x.Description,
                            x.Restaurant.RestaurantName,
                            booker = x.CreatedBy.FullName,
                            x.CreatedBy,
                            RestaurantID = x.Restaurant.Id,
                        },
                        Dishes = x.BookingDishes.Select(d => new
                        {
                            BookingDishID = d.Id,
                            d.DateCreated,
                            d.Dish.Name
                        })
                    });
                }
                else
                {
                    return _appContext.TblBookings.Where(b => b.CreatedBy.Id == UserID).Select(x => new
                    {
                        Book = new
                        {
                            BookingID = x.Id,
                            x.BookingTime,
                            x.TableSize,
                            x.DateCreated,
                            x.Description,
                            x.Restaurant.RestaurantName,
                            booker = x.CreatedBy.FullName,
                            x.CreatedBy,
                            RestaurantID = x.Restaurant.Id,
                        },
                        Dishes = x.BookingDishes.Select(d => new
                        {
                            BookingDishID = d.Id,
                            d.DateCreated,
                            d.Dish.Name
                        })
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic GetBooking(int Id)
        {
            try
            {
                return _appContext.TblBookings.Where(d => d.Id == Id).Select(x => new
                {
                    Book = new
                    {
                        BookingID = x.Id,
                        x.BookingTime,
                        x.TableSize,
                        x.DateCreated,
                        x.Description,
                        x.Restaurant.RestaurantName,
                        booker = x.CreatedBy.FullName,
                        x.CreatedBy,
                        RestaurantID = x.Restaurant.Id,
                    },
                    Dishes = x.BookingDishes.Select(d => new
                    {
                        BookingDishID = d.Id,
                        d.DateCreated,
                        d.Dish.Name
                    })
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic SetBookingStatus(int BookingId, int BookingStatusID)
        {
            try
            {
                var booking = Get(BookingId);
                booking.BookingStatusID = BookingStatusID;
                Update(booking);
                return new
                {
                    Book = new
                    {
                        BookingID = booking.Id,
                        booking.BookingTime,
                        booking.TableSize,
                        booking.DateCreated,
                        booking.Description,
                        booking.Restaurant.RestaurantName,
                        booker = booking.CreatedBy.FullName,
                        booking.CreatedBy,
                        RestaurantID = booking.Restaurant.Id,
                    },
                    Dishes = booking.BookingDishes.Select(d => new
                    {
                        BookingDishID = d.Id,
                        d.DateCreated,
                        d.Dish.Name
                    })
                };
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw;
            }
        }
    }
}
