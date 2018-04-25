using EatListDataService.DataBase;
using EatListDataService.DataTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
    public class OrderRepository : BaseRepository
    {
        public dynamic GetAllByUserID(string UserID)
        {
            try
            {
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
                //var products = entities.TblDishes.Where(p => p.CategoryId == 1);
                var order = entities.TblOrders
                                    .Where(x => x.CreatedBy == UserID)
                                    .Select(d => new { d.ResturantID, d.Status,d.Note,d.DeliveryLocation,d.DateCreated,
                                                       orderDish=entities.TblOrderDish.Where(x=>x.OrderID==d.OrderID).ToList() }).ToList();
               
               
                result.Add("order", order);
               //result.Add("dish", dishes);
                return result;

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }
            // return entities.TblOrders.Where(x => x.CreatedBy == UserId && x.OrderID ==  ).ToList();
        }

        //gets a specific order by OrderID
        public dynamic GetOrder(int OrderID)
        {
            try
            {
                Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
                //var products = entities.TblDishes.Where(p => p.CategoryId == 1);
                var order = entities.TblOrders
                                    .Where(x => x.OrderID == OrderID)
                                    .Select(d => new {
                                        d.ResturantID,
                                        d.Status,
                                        d.Note,
                                        d.DeliveryLocation,
                                        d.DateCreated,
                                        orderDish = entities.TblOrderDish.Where(x => x.OrderID == d.OrderID).ToList()
                                    }).ToList();


                //result.Add("order", order);
                //result.Add("dish", dishes);
                return order;

            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : " + ex.InnerException);

                return null;
            }
            // return entities.TblOrders.Where(x => x.CreatedBy == UserId && x.OrderID ==  ).ToList();
        }

        public List<DataTables.Orders> GetAllResturantID(string ResturandID)
        {
            return entities.TblOrders.Where(x => x.ResturantID == ResturandID ).ToList();
        }

        public DataTables.Orders Insert(DataTables.Orders entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblOrders.Add(entity);
                SaveChange();
                return entity;
            }
            catch(Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }
            
        }

        public List< DataTables.OrderDish> DishInsert(DataTables.OrderDish entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblOrderDish.Add(entity);
                SaveChange();
                return entities.TblOrderDish.Where(e => e.OrderID == entity.OrderID).ToList();
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return null;
            }

        }

        public dynamic OrderStatus(int OrderID, string Status)
        {
            try
            {
                if (entities.TblOrders.Find(OrderID) != null)
                {
                    var entity = entities.TblOrders.Where(x => x.OrderID == OrderID).FirstOrDefault();
                    entity.Status = Status;
                    SaveChange();
                    return GetOrder(entity.OrderID);
                }
                    return null;
            }
            catch (Exception ex)
            {
                //_log.LogInformation("Abeg joor");
                _log.LogInformation(ex.Message + " : "+ex.InnerException+ " : " + ex.StackTrace);

                return ex;
            }
        }
        
    }
}
