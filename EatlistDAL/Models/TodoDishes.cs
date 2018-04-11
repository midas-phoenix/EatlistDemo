using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class TodoDishes: AuditableEntity
    {
        [ForeignKey("Dishes")]
        public int DishID { get; set; }

        public virtual Dishes Dishes { get; set; }
    }
}
