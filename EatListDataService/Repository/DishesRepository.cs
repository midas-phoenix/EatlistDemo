using System;
using System.Collections.Generic;
using System.Text; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;

namespace EatListDataService.Repository
{
    public class DishesRepository
    {
        #region "Declarations"
        private readonly ApplicationDbContext entities;
        readonly ILogger<PostRepository> _log;

        public DishesRepository(ILogger<PostRepository> log )
        {
            _log = log;
            //entities = context;
        }
        public DishesRepository( ApplicationDbContext context)
        {
            //_log = log;
            entities = context;
        }
        //private List<Posts> entities;
        string errorMessage = string.Empty;
        #endregion

        #region "Dishes"
        public List<DataTables.Dishes> GetDishesByUserID(string UserID)
        {
            try
            {
                //var products = entities.TblDishes.Where(p => p.CategoryId == 1);
                return entities.TblDishes.Where(x=>x.RestaurantID==UserID).ToList();
                
            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }

        }
        #endregion

        #region "meta"
        private void SaveChange()
        {
            entities.SaveChanges();
        }
        #endregion

    }
}
