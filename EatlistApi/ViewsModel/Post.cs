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
        //public int PostID { get; set; }
        [Required]
        public string FileURL { get; set; }
        [Required]
        public string FileType { get; set; }
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



}
