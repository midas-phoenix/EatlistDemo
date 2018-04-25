using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistDAL.Models
{
    public class Bookings : AuditableEntity
    {
        public string Description { get; set; }

        public DateTime BookingTime { get; set; }
        
        public int? BookingStatusID { get; set; }
        
        public int? TableSize { get; set; }

        [InverseProperty("Booking")]
        public virtual IEnumerable<BookingDishes> BookingDishes { get; set; }

        public virtual ApplicationUser Restaurant { get; set; }

    }


    public class BookingDishes: AuditableEntity
    {
        
        public virtual Dishes Dish { get; set; }
        
        public virtual Bookings Booking { get; set; }
        

    }
}
