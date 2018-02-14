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

        public int DishID { get; set; }

        public string Description { get; set; }

        public DateTime BookingTime { get; set; }

        public int BookingStatusID { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public int TableSize { get; set; }

       // public List<BookingStatus> Enrollments { get; set; }
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

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
