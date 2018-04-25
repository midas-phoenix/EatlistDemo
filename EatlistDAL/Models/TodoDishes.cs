using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class TodoDishes: AuditableEntity
    {
        public virtual Dishes Dish { get; set; }
    }
}
