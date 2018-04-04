using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class Order
    {
        [Required]
        public string ResturantID { get; set; }
        [Required]
        public string DeliveryLocation { get; set; }
        //[Required]
        public string Note { get; set; }
        
        [Required]
        public List<OrderDish> dishes { get; set; }
    }

    public class OrderDish
    {
        public int OrderID { get; set; }
        public int DishID { get; set; }
        public string Description { get; set; }
    }

    public class Status
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
    }

}
