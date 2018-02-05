using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class VM_Comment
    {
        //public int CommentID { get; set; }
        public int PostID { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
