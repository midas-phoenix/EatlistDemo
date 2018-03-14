using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EatlistApi.ViewsModel;
using EatListDataService.DataBase;
using EatListDataService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EatlistApi.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Base")]
    //[Authorize()]
    public class BaseController : Controller
    {
        #region "Constructor and Declaration"
        //private static    ApplicationDbContext _post = new ApplicationDbContext();
        public PostRepository _postRepo = new PostRepository();

        public BookingRepository _bookRepo = new BookingRepository();
        public DishesRepository _dishRepo = new DishesRepository();
        public EatListRepository _eatRepo = new EatListRepository(new ApplicationDbContext());
        public FriendsRepository _friendRepo = new FriendsRepository(new ApplicationDbContext());
        public UserRepository _userRepo = new UserRepository(new ApplicationDbContext());
        public bool IsRestaurant;
        public static UserManager<ApplicationUser> _userManager;
        //public ILogger<dynamic> _log;


        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            UserID = _userManager.GetUserId(User);
            IsRestaurant = _userRepo.Get(UserID).IsRestaurant;
            //AppUser =_userManager.(UserID);
        }

        public string UserID;
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