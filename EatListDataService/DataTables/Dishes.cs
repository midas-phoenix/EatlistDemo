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
        public int RestaurantID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
