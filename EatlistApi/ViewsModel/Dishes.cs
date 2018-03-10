using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EatlistApi.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Media> Media { get; set; }
    }
    public class Media
    {
        //public int DishID { get; set; }
        public string Url { get; set; }
        public MediaType Type { get; set; }
    }
    public enum MediaType { Image = 0, Audio = 1, Video = 2 }


    public class DishUpd
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Media> Media { get; set; }
        //public string RestaurantID { get; set; }
    }
}
