using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistDAL.Models
{
    public class Bookings : AuditableEntity
    {
        public string RestaurantID { get; set; }
        
        public string Description { get; set; }

        public DateTime BookingTime { get; set; }
        
        public int? BookingStatusID { get; set; }
        
        public int? TableSize { get; set; }

    }


    public class BookingDishes: AuditableEntity
    {

        [ForeignKey("Dishes")]
        public int DishID { get; set; }

        public virtual Dishes Dishes { get; set; }

        [ForeignKey("Bookings")]
        public int BookingID { get; set; }

        public virtual Bookings Bookings { get; set; }
        

    }
}
