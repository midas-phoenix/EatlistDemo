using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Friendship
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FriendshipID { get; set; }
        public int FollowerID { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
