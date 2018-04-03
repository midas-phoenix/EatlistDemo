using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
   public class Orders
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string  CreatedBy { get; set; }
        public string ResturantID { get; set; }
        public DateTime DateCreated { get; set; }
        public string DeliveryLocation { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }

    public class OrderDish
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDishID { get; set; }
        public int OrderID { get; set; }
        public int DishID { get; set; }
        public string Description { get; set; }
    }

    
}
