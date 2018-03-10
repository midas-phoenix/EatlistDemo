﻿using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
   public class EatListRepository
    {
        #region "Declarations"
        private readonly ApplicationDbContext entities;
        readonly ILogger<EatListRepository> _log;

        public EatListRepository(ILogger<EatListRepository> log)
        {
            _log = log;
            //entities = context;
        }
        public EatListRepository(ApplicationDbContext context)
        {
            //_log = log;
            entities = context;
        }
       
        string errorMessage = string.Empty;
        #endregion

        #region "EatList"
        public List<DataTables.ToDoMeals> GetToDoMealsByDishID(int DishID)
        {
            try
            {
              
                return entities.TblToDoMeals.Where(x => x.DishID == DishID).ToList();

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }

        }
        public DataTables.ToDoMeals Insert(DataTables.ToDoMeals entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblToDoMeals.Add(entity);
            SaveChange();
            return entity;
        }
        public DataTables.ToDoMeals Update(DataTables.ToDoMeals entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblToDoMeals.Update(entity);
            SaveChange();
            return entity;
        }
        public void Delete(DataTables.ToDoMeals entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.TblToDoMeals.Remove(entity);
            SaveChange();
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
    

