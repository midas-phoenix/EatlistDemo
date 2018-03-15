using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Comments
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DatePosted { get; set; }
        public string CreatedBy { get; set; }
        
    }
}
