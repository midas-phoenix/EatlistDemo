using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class Dishes: AuditableEntity
    {
        //public Dishes()
        //{
        //    Post = new Collection<Posts>();
        //}
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty("Dish")]
        public virtual ICollection<Posts> Post { get; set; }

    }

    public class DishMedia: AuditableEntity
    {
        [ForeignKey("Dishes")]
        public int DishID { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public virtual Dishes Dishes { get; set; }

    }
}
