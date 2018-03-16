using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Likes
    {

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LikeID { get; set; }
        public int PostID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        //public bool IsLiked { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
