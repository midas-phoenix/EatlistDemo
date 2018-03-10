using EatListDataService.DataTables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatListDataService.DataBase
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsRestaurant { get; set; }
        public string RestaurantName { get; set; }
        public ICollection<Dishes> Dishes { get; set; }


    }
}
