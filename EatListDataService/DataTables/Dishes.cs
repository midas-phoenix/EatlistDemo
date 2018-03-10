using EatListDataService.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Dishes
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishesID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        //[MaxLengthAttribute(500)]
        //public string Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string RestaurantID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class DishMedia
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishMediaID { get; set; }
        [ForeignKey("Dishes")]
        public int DishID { get; set; }
        public virtual Dishes Dishes { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }


}
