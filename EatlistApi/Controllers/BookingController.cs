using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EatlistApi.ViewsModel;
using EatlistDAL;
using EatlistDAL.Models;
using EatlistDAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        #region "Constructor and Declaration"
        //private static readonly ApplicationDbContext _post = new ApplicationDbContext();
        //private readonly BookingRepository _bookRepo = new BookingRepository(new ApplicationDbContext());
        //readonly ILogger<BookingController> _log;
        private Bookings _Bookings = new Bookings();
        private IUnitOfWork _unitOfwork;

        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;//= new UserManager<ApplicationUser>();


        public BookingController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            _unitOfwork = unitOfWork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        #endregion

        #region "Booking"
        /// <summary>
        /// gets all booking by the passed UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>list of bookings by user</returns>
        [HttpGet, Route("GetUserBookings")]
        public async Task<IActionResult> Get()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                _log.LogInformation(userId.Id);
                if (userId.IsRestaurant)
                {
                    var result = _unitOfwork.Bookings.GetAllByUserID(userId.Id, true);
                    if (result == null) { return StatusCode(404); }
                    return Ok(result);
                }
                else
                {
                    var result = _unitOfwork.Bookings.GetAllByUserID(userId.Id, false);
                    if (result == null) { return StatusCode(404); }
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// gets specific booking object by Booking key
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a specific booking objjject by the passed key</returns>
        // GET api/<controller>/5
        [HttpGet, Route("GetBooking/{id}")]
        public dynamic Get(int id)
        {
            try
            {
                var booking = _unitOfwork.Bookings.GetBooking(id);
                if (booking == null) { return StatusCode(404); }
                return booking;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + " " + ex.StackTrace);
                throw;
            }
        }

        // POST api/<controller>
        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody] Book model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ApplicationUser userId = await GetCurrentUserAsync();
                var restaurant = _userManager.Users.Where(i => i.Id == model.RestaurantID).ToList();
                if (!restaurant.Any())
                    return BadRequest("the selected restaurant is invalid");

                _Bookings.Description = model.Description;
                _Bookings.BookingTime = model.BookingTime;
                _Bookings.Restaurant = restaurant.FirstOrDefault();
                _Bookings.TableSize = model.TableSize;
                _Bookings.DateCreated = DateTime.UtcNow;
                _Bookings.CreatedBy = userId;
                var result = _unitOfwork.Bookings.Add(_Bookings);
                if (result == null)
                {
                    return StatusCode(500, new { message = "Your booking failed." });
                }
                else
                {
                    List<BookingDishes> bdshs = new List<BookingDishes>();
                    foreach (var dish in model.DishList)
                    {
                        BookingDishes dishEntity = new BookingDishes { Booking = result, Dish = _unitOfwork.Dishes.Get(dish), DateCreated = DateTime.Now.Date };
                        //_bookRepo.InsertBookingDish(dishEntity);
                        bdshs.Add(dishEntity);
                    }
                    var res = _unitOfwork.Bookingdishes.AddRange(bdshs);
                }
                //return Ok(Get(result.BookingID));
                //return Ok(Get());
                if (userId.IsRestaurant)
                {
                    //if (_bookRepo.GetAllByUserID(UserID) == null) { return StatusCode(404); }
                    return Ok(_unitOfwork.Bookings.GetAllByUserID(userId.Id, true));
                }
                else
                {
                    //if (_bookRepo.GetAllByUserID(UserID) == null) { return StatusCode(404); }
                    return Ok(_unitOfwork.Bookings.GetAllByUserID(userId.Id, false));
                }
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Source + " : " + ex.Message);
                return StatusCode(500, new { message = "An error occured while creating your booking." });
            }
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> Update([FromBody]BookUpd model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }
                ApplicationUser userId = await GetCurrentUserAsync();

                _Bookings = _unitOfwork.Bookings.GetBooking(model.BookingID);//["Booking"];
                _Bookings.Description = model.Description;
                _Bookings.BookingTime = model.BookingTime;
                _Bookings.TableSize = model.TableSize;
                var retObj = _unitOfwork.Bookings.Update(_Bookings);
                if (retObj == null)
                {
                    return StatusCode(500);
                }
                else
                {
                    //var delResult = _bookRepo.DeleteDishesByBookingID(id);
                    if (_unitOfwork.Bookingdishes.DeleteDishesByBookingID(model.BookingID))
                    {
                        List<BookingDishes> bdshs = new List<BookingDishes>();
                        foreach (var dish in model.DishList)
                        {
                            //BookingDishes dishEntity = new BookingDishes { BookingID = dish.BookID, DishID = dish.DishID };
                            //_bookRepo.InsertBookingDish(dishEntity);

                            BookingDishes dishEntity = new BookingDishes { Booking = retObj, Dish = _unitOfwork.Dishes.Get(dish), DateCreated = DateTime.Now.Date };
                            bdshs.Add(dishEntity);
                        }
                        var res = _unitOfwork.Bookingdishes.AddRange(bdshs);
                    }
                    else
                    {

                        return StatusCode(500);
                    }
                }
                return Ok(_unitOfwork.Bookings.GetAllByUserID(userId.Id, userId.IsRestaurant));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.StackTrace);
                return StatusCode(500);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                return _unitOfwork.Bookings.Remove(_unitOfwork.Bookings.Get(id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.ToString());
                return false;
            }

        }
        #endregion

        #region "BookingMiscellaneous"
        [HttpPost, Route("setStatus")]
        public IActionResult setBookingStatus(int BookingID, int BookingStatusID)
        {
            try
            {
                var ret = _unitOfwork.Bookings.SetBookingStatus(BookingID, BookingStatusID);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ":" + ex.InnerException);
                return StatusCode(500);
            }
        }

        //[HttpGet, Route("getStatus")]
        //public IActionResult getBookingStatus(int BookingID)
        //{
        //    try
        //    {
        //        var ret = _bookRepo.GetBookingStatus(BookingID);
        //        if (ret == null)
        //        {
        //            return StatusCode(404);
        //        }
        //        return Ok(new { ret.StatusName,ret.Description });
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogInformation(ex.Message + ":" + ex.InnerException);
        //        return StatusCode(500);
        //    }
        //}

        #endregion
    }
}
