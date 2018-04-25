using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class BookingDishesRepository : Repository<BookingDishes>, IBookingDishesRepository
    {
        public BookingDishesRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public bool DeleteDishesByBookingID(int BookingID)
        {
            try
            {
                List<BookingDishes> bds = _appContext.TblBookingDishes.Where(x => x.Booking.Id == BookingID).ToList();
                return RemoveRange(bds);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw;
            }
        }
    }
}
