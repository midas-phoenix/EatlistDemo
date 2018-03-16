using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class VM_Comment
    {
        //public int CommentID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
