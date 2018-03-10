
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Posts
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }
        public string Caption { get; set; }
        public int? DishID { get; set; }
        public string RestaurantID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        //public App

    }

    public class PostsMedia
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostMediaID { get; set; }
        public int PostID { get; set; }
        public string FileURL { get; set; }
        public string FileType { get; set; }


    }
}
