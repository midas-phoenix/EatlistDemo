 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.Models
{
    public class PostFile
    {
        //public int PostID { get; set; }
        [Required]
        public string FileURL { get; set; }
        [Required]
        public string FileType { get; set; }

    }

    public class Post
    {
        public string Caption { get; set; }
        //[Required]
        public int? DishID { get; set; }
        //[Required]
        public string RestaurantID { get; set; }
        //public DateTime DateCreated { get; set; }
        //[Required]
        //public string CreatedBy { get; set; }
        [Required]
        public List<PostFile> PostFiles { get; set; }

    }

    public class Update
    {
        [Required]
        public int PostID { get; set; }
        [Required]
        public string FileURL { get; set; }
        [Required]
        public string FileType { get; set; }
    }



    public class LikePost
    {
        [Required]
        public int PostID { get; set; }
    }

}
