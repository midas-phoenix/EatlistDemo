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


        public BaseController()
        {
            IsRestaurant = _userRepo.Get(UserID).IsRestaurant;
            //AppUser =_userManager.(UserID);
        }
        
        public string UserID
        {
            get
            {
                return _userManager.GetUserId(User);
            }
            set { }

        }

        #endregion

    }
}