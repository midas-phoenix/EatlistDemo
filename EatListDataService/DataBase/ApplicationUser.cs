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
        public string Bio { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doi { get; set; }
        public string RestaurantName { get; set; }
        public string profilepic { get; set; }
        public string profilepicName { get; set; }
        public ICollection<Dishes> Dishes { get; set; }


    }
}
