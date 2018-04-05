using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Bookings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key()]
        public int BookingID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string RestaurantID { get; set; }

        //public int? DishID { get; set; }

        public string Description { get; set; }

        public DateTime BookingTime { get; set; }

        //[ForeignKey("BookingStatus")]
        public int? BookingStatusID { get; set; }

        public DateTime? DateCreated { get; set; }

        //[ForeignKey("ApplicationUser")]
        public string CreatedBy { get; set; }

        public int? TableSize { get; set; }

       // public virtual BookingStatus BookingStatus { get; set; }

        //[ForeignKey("BookingDish")]
        //public int BookingDishID { get; set; }
        public virtual ICollection<BookingDishes> BookingDish { get; set; }

    }

    public class BookingStatus
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingStatusID { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        //public ICollection<Bookings> Bookings { get; set; }
    }

    public class BookingDishes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key()]
        public int BookingDishID { get; set; }

        [ForeignKey("Dishes")]
        public int DishID { get; set; }
        public virtual Dishes Dishes { get; set; }

        [ForeignKey("Bookings")]
        public int BookingID { get; set; }

        public virtual Bookings Bookings { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}
