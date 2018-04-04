using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatListDataService.DataTables;
using Microsoft.EntityFrameworkCore;
//using System.Data.E
namespace EatListDataService.Repository
{
    public class BookingRepository : BaseRepository
    {
        //public BookingRepository(ApplicationDbContext context) : base(context)
        //{
            
        //}


        #region "Bookings"
        public dynamic GetAllByUserID(string UserID)
        {
            //var 
            try
            {
                List<dynamic> result=new List<dynamic>();
                var IDS=entities.TblBookings.Where(x => x.CreatedBy == UserID).Select(x=>x.BookingID).ToList();
                foreach (int id in IDS) { result.Add(Get(id)); }
                return result;
            }
            catch(Exception ex)
            {
                _log.LogDebug(ex.Message+ ":" +ex.StackTrace);
                throw ex;
            }
            
        }

        public dynamic GetAllByUserID(string UserID,bool IsRestaurant)
        {
            //var 
            try
            {
                List<dynamic> result = new List<dynamic>();
                List<int> IDS;
                if (IsRestaurant)
                {
                    IDS = entities.TblBookings.Where(x => x.RestaurantID == UserID).Select(x => x.BookingID).ToList();
                }
                else
                {
                    IDS = entities.TblBookings.Where(x => x.CreatedBy == UserID).Select(x => x.BookingID).ToList();

                }

                foreach (int id in IDS) { result.Add(Get(id)); }
                return result;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }

        }

        public Bookings GetSpecific(long id)
        {
            try
            {
                var blogs = entities.TblBookings
                                    .Where(b=>b.BookingID==id)
                                    //.Include(book => book.BookingStatus)
                                    //.Include(book => book.BookingDish)
                                    .FirstOrDefault();
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
                //List<dynamic> res = new List<dynamic>();
                var Book = entities.TblBookings.Where(x => x.BookingID == id).FirstOrDefault();

                                    //.Select(b => new { b.BookingID, b.BookingStatus, b.BookingTime, b.DateCreated, b.Description,b.BookingStatusID }).FirstOrDefault();
                var Dishes = entities.TblBookingDishes.Where(x => x.BookingID == id)
                                    .Select(d => new { d.Dishes.Name, d.Dishes.RestaurantID, d.Dishes.DateCreated }).ToList();

                //res.AddRange("BookingID",Book.BookingID);
                //res.Add(Book.BookingStatus);
                //res.Add(Book.BookingTime);
                //res.Add(Book.DateCreated);
                //res.Add(Book.Description);
                res.Add("Booking", Book);


                res.Add("Dishes", Dishes);
                return blogs;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }

        }
        public dynamic Get(long id)
        {
            try
            {
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
                //List<dynamic> res = new List<dynamic>();
                //var Book = entities.Users     //.Where(x => x.BookingID == id)
                //                    .Join(entities.TblBookings, // the source table of the inner join
                //                            user => user.Id,          // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                //                            book => book.RestaurantID, // Select the foreign key (the second part of the "on" clause)
                //                            (user, book) => new { book.BookingID, book.BookingStatus,
                //                                                  book.BookingTime, book.DateCreated,
                //                                                  book.Description, book.RestaurantID,
                //                                                  user.FullName, user.RestaurantName, user.IsRestaurant,
                //                                                }) // selection
                //                    .Where(booking => booking.BookingID == id).FirstOrDefault();    // where statement                


                var Book =    from user in entities.Users
                               join book in entities.TblBookings on user.Id equals book.RestaurantID
                              //join booker in entities.TblBookings on user.Id equals booker.CreatedBy
                              where book.BookingID == id
                               select new
                               {
                                   book.BookingID,
                                   book.BookingStatus,
                                   book.BookingTime,
                                   book.DateCreated,
                                   book.Description,
                                   book.RestaurantID,
                                   book.CreatedBy,
                                   //booker.
                                   booker=entities.Users.Where(x=>x.Id==book.CreatedBy).FirstOrDefault().FullName,
                                   book.TableSize,
                                   user.FullName,
                                   user.RestaurantName,
                                   user.IsRestaurant,
                               };
                //.Select(b =>new { b.BookingID,b.BookingStatus,b.BookingTime,b.DateCreated,b.Description,b.RestaurantID }).FirstOrDefault();
                // dynamic BooEx = new { Book,entities.Users.Where(x=>x.Id===Book.RestaurantID).FirstOrDefault()};
                var Dishes = entities.TblBookingDishes.Where(x => x.BookingID == id)
                                    .Select( d=>new { d.Dishes.Name,d.Dishes.RestaurantID,d.Dishes.DateCreated}).ToList();

                //res.AddRange("BookingID",Book.BookingID);
                //res.Add(Book.BookingStatus);
                //res.Add(Book.BookingTime);
                //res.Add(Book.DateCreated);
                //res.Add(Book.Description);
                //object vbook = Book.Single()
                res.Add("Booking",Book.Single());
                
                
                res.Add("Dishes",Dishes);
                return res;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
           
        }

        public DataTables.Bookings Insert(DataTables.Bookings entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblBookings.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.InnerException + ":" + ex.StackTrace);
                throw ex;
            }
            
        }

        public DataTables.Bookings Update(DataTables.Bookings entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                if (entities.TblBookings.Find(entity.BookingID) == null)
                {
                    throw new NullReferenceException();
                }
                entities.TblBookings.Update(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
        }

        //Do we delete or cancel
        public bool Delete(DataTables.Bookings entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var ret=DeleteDishesByBookingID(entity.BookingID);
                entities.TblBookings.Remove(entity);
                SaveChange();
                return ret;
                
            }
            catch(Exception ex)
            {
                _log.LogDebug(ex.Message+ ":" +ex.StackTrace);
                return false;
            }
            
        }

        #endregion

        #region "BookingDishes"
        public dynamic GetDishesByBookingID(int BookingID)
        {
            try
            {
                return entities.TblBookingDishes.Where(x => x.BookingID == BookingID).ToList();
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
        }

        public bool DeleteDishesByBookingID(int BookingID)
        {
            try
            {
                entities.TblBookingDishes.RemoveRange(entities.TblBookingDishes.Where(x => x.BookingID == BookingID).ToList());
                SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                return false;
            }

        }

        public dynamic DeleteDishesByBookingDishID(int BookingDishID)
        {
            try
            {
                entities.TblBookingDishes.Remove(entities.TblBookingDishes.Where(x => x.BookingDishID == BookingDishID).FirstOrDefault());
                SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }

        }

        public DataTables.BookingDishes InsertBookingDish(DataTables.BookingDishes entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblBookingDishes.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
        }

        #endregion

        #region "BookingStatus"
        public DataTables.BookingStatus InsertBookingStatus(DataTables.BookingStatus entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.TblBookingStatus.Add(entity);
                SaveChange();
                return entity;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
        }
        
        //gets by join
        public BookingStatus GetBookingStatus(int BookingID)
        {
            try
            {
                var viewableBookings = (from Booking in entities.TblBookings
                                        join BStatus in entities.TblBookingStatus on Booking.BookingStatusID equals BStatus.BookingStatusID
                                        where Booking.BookingID == BookingID
                                        select BStatus).FirstOrDefault();
                                     
                return viewableBookings;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }   
        }
        //gets from Booking table
        public dynamic GetBookingStat(int BookingID)
        {
            try
            {
                return entities.TblBookings.FirstOrDefault(x => x.BookingID == BookingID).BookingStatus;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
        }
        
        //public dynamic SetBookingStatus(DataTables.Bookings entity,int BookingStatusID)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }
        //        var entityObj = entities.TblBookings.Find(entity);
        //        if (entityObj == null)
        //        {
        //            throw ex;
        //        }
        //        entityObj.BookingStatusID = BookingStatusID;
        //        entities.TblBookings.Update(entityObj);
        //        SaveChange();
        //        return entityObj;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogDebug(ex.Message + ":" + ex.StackTrace);
        //        throw ex;
        //    }
            
            
        //}

        public dynamic SetBookingStatus(int EntityID, int BookingStatusID)
        {
            try
            {
                var entityObj = entities.TblBookings.Find(EntityID);
                if (entityObj == null)
                {
                    throw new NullReferenceException();
                }
                entityObj.BookingStatusID = BookingStatusID;
                entities.TblBookings.Update(entityObj);
                SaveChange();
                return entities.TblBookings.Where(b => b.BookingID == entityObj.BookingID).Include(b => b.BookingStatus);//.ThenInclude(bs => bs.StatusName);
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message + ":" + ex.StackTrace);
                throw ex;
            }
            
        }

        #endregion

    }
}
