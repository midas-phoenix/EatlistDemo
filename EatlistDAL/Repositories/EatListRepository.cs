using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatlistDAL.Repositories
{
    public class EatListRepository : Repository<TodoDishes>, IEatListRepository
    {
        public EatListRepository(DbContext context, Microsoft.Extensions.Logging.ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public TodoDishes EatlistExist(string UserId, int DishId)
        {
            try
            {
                return _appContext.TodoDishes.Where(t => t.CreatedBy.Id == UserId && t.Dish.Id == DishId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic GetEatList(int ID)
        {
            try
            {
                var x = Get(ID);
                return new
                {
                    EatListID = x.Id,
                    DishName = x.Dish.Name,
                    DishID = x.Dish.Id,
                    x.DateCreated,
                    RestaurantId = x.Dish.CreatedBy.Id,
                    x.Dish.CreatedBy.RestaurantName,
                    CreatedBy = x.CreatedBy.Id,
                    CreatedByName = x.CreatedBy.FullName,
                    x.CreatedBy.profilepic

                };
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }

        public dynamic GetUserDishList(string UserID)
        {

            try
            {
                return _appContext.TodoDishes.Where(t => t.CreatedBy.Id == UserID).Select(x => new
                {
                    EatListID = x.Id,
                    DishName = x.Dish.Name,
                    DishID = x.Dish.Id,
                    x.DateCreated,
                    RestaurantId = x.Dish.CreatedBy.Id,
                    x.Dish.CreatedBy.RestaurantName,
                    CreatedBy = x.CreatedBy.Id,
                    CreatedByName = x.CreatedBy.FullName,
                    x.CreatedBy.profilepic
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
    }
}
