using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class Orders: AuditableEntity
    {
        public string ResturantID { get; set; }
        public string DeliveryLocation { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }

    public class OrderDish: AuditableEntity
    {

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [ForeignKey("Dishes")]
        public int DishID { get; set; }

        public string Description { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Dishes Dishes { get; set; }
    }
}
