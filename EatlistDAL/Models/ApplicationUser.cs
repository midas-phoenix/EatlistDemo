using EatlistDAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public ApplicationUser()
        //{
        //    PCreatedBy = new Collection<Posts>();
        //}
        public string FullName { get; set; }
        public bool IsRestaurant { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doi { get; set; }
        public string RestaurantName { get; set; }
        public string profilepic { get; set; }
        public string profilepicName { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Dishes> Dishes { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<Posts> RestaurantInPost { get; set; }
        //[InverseProperty("ApplicationUser")]
        public virtual ICollection<Posts> PCreatedBy { get; set; }

        [InverseProperty("Friends")]
        public virtual ICollection<Friendship> Friends { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Friendship> FCreatedBy { get; set; }

        public virtual ICollection<Likes> Likes { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<ChatMessages> Recipient { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<ChatMessages> CCreatedBy { get; set; }
        
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Likes> LCreatedBy { get; set; }
        
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Comments> CoCreatedBy { get; set; }

    }

    public class Friendship: AuditableEntity
    {
        [ForeignKey("Friends")]
        public string FollowerID { get; set; }

        public virtual ApplicationUser Friends { get; set; }
    }
}
