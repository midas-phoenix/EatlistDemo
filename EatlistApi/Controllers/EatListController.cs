using EatlistApi.ViewsModel;
using EatListDataService.DataBase;
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
    public class EatListController
    {
        #region "Declaration"
        private static readonly ApplicationDbContext _EatList = new ApplicationDbContext();
        private readonly EatListRepository _eatlistRepo = new EatListRepository(_EatList);
        readonly ILogger<EatListController> _log;
        private EatList _EatLists = null;
       
        string DishID = "2";


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

        // GET api/<controller>/5
        [HttpGet, Route("todos/{ToDoID}")]
        public IActionResult Get(int DishID)
        {

            return Ok(_eatlistRepo.GetToDoMealsByDishID(DishID));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


    }
}

    

