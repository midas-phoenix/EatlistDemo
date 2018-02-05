using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class ToDoMeals
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToDoID { get; set; }
        public int DishID { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

       // public ICollection<Enrollment> Enrollments { get; set; }
    }
}
