using System;
using System.Collections.Generic;
using System.Text;
using EatlistDAL.Models;

namespace EatlistDAL.Repositories.Interfaces
{
    public interface IBookingRepository: IRepository<Bookings>
    {
        dynamic GetAllByUserID(string UserID, bool IsRestaurant);

        dynamic GetBooking(int Id);

        dynamic SetBookingStatus(int BookingId, int BookingStatusID);
    }

    public interface IBookingDishesRepository : IRepository<BookingDishes>
    {
        bool DeleteDishesByBookingID(int BookingID);
    }
}
