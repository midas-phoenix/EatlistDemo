using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatListDataService.DataTables;
namespace EatlistApi.Models
{
    public class ProfileUpload//:Upload
    {
        //[Key()]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UploadID { get; set; }

        //public Guid UserID { get; set; }

        public string FileUrl { get; set; }

        public bool IsProfile { get; set; }
    }

    public class Restaurant//:Upload
    {
        public string RestaurantName { get; set; }

        public bool IsRestaurant { get; set; }
    }

    public class UserData
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Bio { get; set; }

        public string Address { get; set; }

        public int Gender { get; set; }

        public DateTime Dob { get; set; }

        public string RestaurantName { get; set; }

        public DateTime Doi { get; set; }
    }
}