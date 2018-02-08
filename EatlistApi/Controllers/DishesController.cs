using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatListDataService.DataBase;
using EatListDataService.DataTables;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatlistApi.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        #region "Declaration"
        private static readonly ApplicationDbContext _dish = new ApplicationDbContext();
        private readonly DishesRepository _dishRepo = new DishesRepository(_dish);
        readonly ILogger<DishesController> _log;
        private Dishes _Dishes = null;
        //UserID will be changed
        string UserID = "03503819-15ce-489c-946e-ff86a5324189";


        public DishesController(ILogger<DishesController> log)
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
        [HttpGet, Route("users/{UserID}")]
        public IActionResult Get(string UserID)
        {

            return Ok(_dishRepo.GetDishesByUserID(UserID));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
    }
}
