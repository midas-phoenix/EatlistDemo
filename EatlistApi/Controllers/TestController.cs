using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatListDataService.DataBase;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EatlistApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        #region "Constructor and Declaration"
        //private static readonly ApplicationDbContext _post = new ApplicationDbContext();
        public readonly PostRepository _postRepo = new PostRepository();

        public readonly BookingRepository _bookRepo = new BookingRepository();
        public readonly DishesRepository _dishRepo = new DishesRepository();
        public readonly EatListRepository _eatRepo = new EatListRepository(new ApplicationDbContext());
        public readonly FriendsRepository _friendRepo = new FriendsRepository(new ApplicationDbContext());
        public readonly UserRepository _userRepo = new UserRepository(new ApplicationDbContext());
        public bool IsRestaurant;
        private static UserManager<ApplicationUser> _userManager;
        public ILogger<dynamic> _log;

        public string UserID = "e61538cf-eebd-49ac-b752-996aa428f963";// "44e1e1e8-6bbd-4a2b-b8e9-7d9e5d937358";

        
        public TestController()
        {
            IsRestaurant = false;
            //IsRestaurant = _userRepo.Get(UserID).IsRestaurant;
            //AppUser =_userManager.(UserID);
        }

        //public string UserID
        //{
        //    get
        //    {
        //        return _userManager.GetUserId(User);
        //    }
        //    set { }

        //}

        #endregion

    }
}