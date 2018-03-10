using EatListDataService.DataTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class Book
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }
        public string RestaurantID { get; set; }
        public int? TableSize { get; set; }
        public List<int> DishList { get; set; }
    }

    public class BookUpd
    {
        [Required]
        public int BookingID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

        public string RestaurantID { get; set; }

        public int? TableSize { get; set; }

        public List<int> DishList { get; set; }

    }
    public class BookDish
    {
        public int DishID { get; set; }

        public int BookID { get; set; }

    }
}
