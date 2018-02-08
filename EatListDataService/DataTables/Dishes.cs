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
        public DateTime DateCreated { get; set; }
        
        //[MaxLengthAttribute(500)]
        //public string Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string RestaurantID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
