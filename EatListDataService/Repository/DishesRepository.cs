using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EatListDataService.Repository
{
    public class DishesRepository : BaseRepository
    {
        #region "Declarations"

        //public DishesRepository(ApplicationDbContext context) : base(context)
        //{

        //}

        //string errorMessage = string.Empty;
        #endregion

        #region "Dishes"
        public DataTables.Dishes Get(long id)
        {
            try
            {
                var dishes = entities.TblDishes
                                    .Where(d => d.DishesID == id)
                                    .Include(d => d.ApplicationUser)
                                    //.Select(d=>d.)
                                    .FirstOrDefault();
                return dishes;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }

        public dynamic GetDishMedia(long id)
        {
            try
            {
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
                var res = from dsh in entities.TblDishes
                          join usr in entities.Users on dsh.RestaurantID equals usr.Id
                          //join med in entities.TblDishMedia on dsh.DishesID equals med.DishID
                          where dsh.DishesID == id
                          select new
                          {
                              dsh.DishesID,
                              dsh.Name,
                              dsh.Description,
                              dsh.RestaurantID,
                              usr.UserName,
                              usr.FullName,
                              usr.IsRestaurant,
                              usr.RestaurantName,
                          };
                var media = entities.TblDishMedia.Where(x => x.DishID == id).Select(dm => new { dm.Url, dm.Type, dm.FileName }).ToList();
                var tagIDs = entities.TblTags.Where(x => x.DishID == id).Select(dm => dm.DishID).ToList();
                List<dynamic> tags = new List<dynamic>();
                foreach (var ids in tagIDs)
                {
                    tags.Add(entities.TblDishes.Where(x => x.DishesID == ids).Select(dm => new { dm.Name, dm.Description }).First());
                }
                result.Add("id", res.First().DishesID);
                result.Add("name", res.First().Name != null ? res.First().Name : " ");
                result.Add("description", res.First().Description);
                result.Add("fullName", res.First().FullName);
                result.Add("restaurantName", res.First().RestaurantName);
                result.Add("createdBy", res.First().RestaurantID);
                result.Add("tags", tags != null ? tags : new List<dynamic>());
                result.Add("media", media);
                return result;

            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }

        public DataTables.Dishes Insert(DataTables.Dishes entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblDishes.Add(entity);
                SaveChange();
                //return entities.TblDishes.Where(e=>e.DishesID==entity.DishesID).Include(dish => dish.ApplicationUser).ThenInclude(user=>user.Id).FirstOrDefault();
                return entities.TblDishes
                                .Where(e => e.DishesID == entity.DishesID)
                                //.Include(dish => dish.ApplicationUser.RestaurantName==null? dish.ApplicationUser.FullName: dish.ApplicationUser.RestaurantName)
                                .Include(dish => dish.ApplicationUser)
                                .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                //return null;
                throw ex;
            }

        }

        public dynamic GetDishesByUserID(string UserID)
        {
            try
            {
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
                //var user = entities.TblDishes
                //                    .Where(x => x.RestaurantID == UserID)
                //                    .Include(d => d.ApplicationUser)
                //                    .Select(d=>new { d.ApplicationUser.FullName, d.ApplicationUser.UserName, d.ApplicationUser.RestaurantName })
                //                    .FirstOrDefault();
                _log.LogInformation("testing...");
                dynamic dishes = entities.TblDishes.Where(x => x.RestaurantID == UserID).Select(d => new
                {
                    d.DishesID,
                    d.Name,
                    d.RestaurantID,
                    d.DateCreated,
                    d.Description,
                    CreatedBy = d.RestaurantID,
                    entities.Users.Where(x => x.Id == d.RestaurantID).FirstOrDefault().RestaurantName,
                    dishmedias = entities.TblDishMedia.Where(dm => dm.DishID == d.DishesID).Select(m => new { m.Url, m.Type }).ToList()
                }).ToList();
                string user = JsonConvert.SerializeObject(dishes);
                _log.LogInformation(user);
                //result.Add("user", user);
                //result.Add("dish", dishes);
                //return result;
                return dishes;

            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " : " + ex.InnerException + " : " + ex.StackTrace);

                return ex;
            }

        }

        public DataTables.Dishes Update(DataTables.Dishes entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                if (entities.TblDishes.Find(entity.DishesID) == null)
                {
                    return null;
                }
                entities.TblDishes.Update(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }
        }

        //Do we delete or cancel
        public bool Delete(DataTables.Dishes entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                //var ret = DeleteDishesByBookingID(entity.BookingID);
                entities.TblDishes.Remove(entity);
                SaveChange();
                return true;

            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return false;
            }

        }

        #endregion

        #region "meta"
        public List<DataTables.DishMedia> MediaInsert(DataTables.DishMedia entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblDishMedia.Add(entity);
                SaveChange();

                return entities.TblDishMedia
                                .Where(e => e.DishID == entity.DishID)
                                .ToList();

            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }

        public bool DeleteMedia(int DishID)
        {
            try
            {
                //var ret = DeleteDishesByBookingID(entity.BookingID);
                entities.TblDishMedia.RemoveRange(entities.TblDishMedia.Where(dm => dm.DishID == DishID).ToList());
                SaveChange();
                return true;

            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return false;
            }

        }

        public List<DataTables.DishMedia> GetMedia(long id)
        {
            try
            {
                return entities.TblDishMedia.Where(x => x.DishID == id)
                                //.Select(dm => new { dm.Url, dm.Type, })
                                .ToList(); ;

            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }


        #endregion


    }
}
