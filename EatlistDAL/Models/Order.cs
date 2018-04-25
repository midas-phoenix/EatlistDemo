using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class Orders : AuditableEntity
    {
        public string DeliveryLocation { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderDish> OrderDish { get; set; }

        public virtual ApplicationUser Restaurant { get; set; } 
    }

    public class OrderDish : AuditableEntity
    {
        public string Description { get; set; }

        public virtual Orders Order { get; set; }

        public virtual Dishes Dish { get; set; }
    }
}
