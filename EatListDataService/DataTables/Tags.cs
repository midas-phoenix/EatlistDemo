using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Tags
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagID { get; set; }
        public int DishID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
