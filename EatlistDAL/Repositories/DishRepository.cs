using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EatlistDAL.Repositories
{
    public class DishRepository : Repository<Dishes>, IDishRepository
    {
        public DishRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public dynamic GetDishByUserID(string UserID)
        {
            try
            {
                return _appContext.TblDishes.Where(x => x.CreatedBy.Id == UserID).Select(y => new
                {
                    y.Id, y.Name, y.Description,
                    CreatedBy=y.CreatedBy.Id, y.CreatedBy.RestaurantName,
                    dishmedias = y.DishMedia.Select(m=>new
                    {
                        m.FileName, m.Url, m.Type
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

    public class DishMediaRepository : Repository<DishMedia>, IDishMediaRepository
    {
        public DishMediaRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        private ILogger<dynamic> logger => (ILogger<dynamic>)_log;

        public IEnumerable< DishMedia> GetMediaByDishID(int dishId)
        {
            try
            {
                return _appContext.TblDishMedia.Where(d => d.Dish.Id == dishId).ToList();
                //    .Select(e => new {
                //    e.Id, e.Type, e.FileName,DishID = e.Dish.Id, DishName = e.Dish.Name, e.Dish.Description
                //});
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);
                throw ex;
            }
        }
        
    }
}
