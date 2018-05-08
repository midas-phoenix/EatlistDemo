using EatlistApi.ViewsModel;
using EatlistDAL;
using EatlistDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatlistApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    public class EatListController : Controller
    {
        #region "Declaration"
        private IUnitOfWork _unitOfWork;
        public ILogger<dynamic> _log;
        private static UserManager<ApplicationUser> _userManager;


        public EatListController(ILogger<dynamic> log, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _log = log;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //public EatListController(ILogger<EatListController> log)
        //{
        //    _log = log;
        //    _userManager = userManager;
        //    Configuration = configuration;
        //    _unitOfWork = unitOfWork;
        //}
        #endregion

        [HttpGet, Route("MyEatlist")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                return Ok(_unitOfWork.EatList.GetUserDishList(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { Message = "An error occurred" });
            }
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> EatListAsync(int DishID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ApplicationUser userId = await GetCurrentUserAsync();
                
                if (!_unitOfWork.EatList.EatlistExist(userId.Id,DishID).Equals(null))
                    return StatusCode(304,new { Message="this dish already exist"});

                TodoDishes _EatLists = new TodoDishes();
                _EatLists.Dish = _unitOfWork.Dishes.Get(DishID);
                _EatLists.DateCreated = DateTime.UtcNow;
                _EatLists.CreatedBy = userId;
                _unitOfWork.EatList.Add(_EatLists);

                return Ok(_unitOfWork.EatList.GetUserDishList(userId.Id));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { Message= "An error occurred"});
            }

        }

        //[HttpPut, Route("update")]
        //public IActionResult Update(EatList update)
        //{
        //    try
        //    {


        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        TodoDishes _EatLists =_unitOfWork.EatList.Get(update.ToDoID);
        //        _EatLists.Id = update.ToDoID;
        //        _EatLists.DishID = update.DishID;
        //        //_EatLists.DateCreated = DateTime.UtcNow;
        //        //_EatLists.CreatedBy = UserID;

        //        _eatlistRepo.Update(_EatLists);
        //        var res = _eatlistRepo.Update(_EatLists);
        //        if (res.GetType() == typeof(KeyNotFoundException))
        //        {
        //            _log.LogInformation(res.ToString());
        //            return StatusCode(500);
        //        }
        //        return Ok(res);

        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogInformation(ex.Message.ToString());
        //        return StatusCode(500);
        //    }
        //}
        //DELETE api/<controller>/5

        /// <summary>
        /// delete posts
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                ApplicationUser userId = await GetCurrentUserAsync();
                if (_unitOfWork.EatList.Remove(_unitOfWork.EatList.Get(id)))
                {
                    return Ok(_unitOfWork.EatList.GetUserDishList(userId.Id));
                }
                return BadRequest("sorry, this item could not be removed");
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { Message = "An error occurred" });
            }
        }

        // GET api/<controller>/5
        [HttpGet, Route("todos/{DishID}")]
        public IActionResult Get(int DishID)
        {
            try
            {
            return Ok(_unitOfWork.EatList.GetEatList(DishID));
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message + ex.StackTrace);
                return StatusCode(500, new { Message = "An error occurred" });
            }
        }
    }
}



