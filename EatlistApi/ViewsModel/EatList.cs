using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class EatList
    {
        [Key]
        public int ToDoID { get; set; }
        public int DishID { get; set; }
        //public DateTime DateCreated { get; set; }
        //public string CreatedBy { get; set; }
    }
}
