using EatlistApi.Models;
using EatlistApi.ViewsModel;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class EatListController: Controller
    {
        #region "Declaration"
        private static readonly ApplicationDbContext _EatList = new ApplicationDbContext();
        private readonly EatListRepository _eatlistRepo = new EatListRepository(_EatList);
        readonly ILogger<EatListController> _log;
        private ToDoMeals _EatLists = new ToDoMeals();

        int DishID = 2;
        string UserID = "03503819-15ce-489c-946e-ff86a5324189";


        public EatListController(ILogger<EatListController> log)
        {
            _log = log;
        }
        #endregion

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost, Route("create")]
        public IActionResult EatList(int DishID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _EatLists = new ToDoMeals();
            _EatLists.DishID = DishID;
            _EatLists.DateCreated = DateTime.UtcNow;
            _EatLists.CreatedBy = UserID;

            return Ok(_eatlistRepo.Insert(_EatLists));
        }

        [HttpPut, Route("update")]
        public IActionResult Update(EatList update)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _EatLists.ToDoID = update.ToDoID;
                _EatLists.DishID = update.DishID;
                //_EatLists.DateCreated = DateTime.UtcNow;
                //_EatLists.CreatedBy = UserID;

                _eatlistRepo.Update(_EatLists);
                var res = _eatlistRepo.Update(_EatLists);
                if (res.GetType() == typeof(KeyNotFoundException))
                {
                    _log.LogInformation(res.ToString());
                    return StatusCode(500);
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                _log.LogInformation(ex.Message.ToString());
                return StatusCode(500);
            }
        }
        //DELETE api/<controller>/5

        /// <summary>
        /// delete posts
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<controller>/5
        [HttpGet, Route("todos/{DishID}")]
        public IActionResult Get(int DishID)
        {

            return Ok(_eatlistRepo.GetToDoMealsByDishID(DishID));
        }
    }
}

    

