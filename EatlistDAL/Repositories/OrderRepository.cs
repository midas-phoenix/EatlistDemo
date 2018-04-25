using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EatlistDAL.Repositories
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        public OrderRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetAllByUserID(string UserID, bool Restaurant)
        {
            try
            {
                if (Restaurant)
                    return formatOrderResponse(_appContext.TblOrders.Where(o => o.Restaurant.Id == UserID).ToArray());
                else
                    return formatOrderResponse(_appContext.TblOrders.Where(o => o.CreatedBy.Id == UserID).ToArray());
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        private dynamic formatOrderResponse(Orders[] orders)
        {
            try
            {
                return orders.Select(z => new
                {
                    OrderId = z.Id,
                    z.Note,
                    z.Status,
                    z.DeliveryLocation,
                    RestaurantId = z.Restaurant.Id,
                    z.DateCreated,
                    z.Restaurant.RestaurantName,
                    z.CreatedBy,
                    CreatedByName = z.CreatedBy.FullName,
                    orderDish = z.OrderDish.Select(od => new
                    {
                        OrderDishID = od.Id,
                        od.Description,
                        DishId = od.Dish.Id,
                        DishName = od.Dish.Name
                    })
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
    }

    public class OrderDishRepository : Repository<OrderDish>, IOrderDishRepository
    {
        public OrderDishRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;
    }
}
