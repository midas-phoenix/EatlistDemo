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
        #region columns
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
        #endregion

        #region Relationships
        [InverseProperty("CreatedBy")]
        public virtual ICollection<Dishes> Dishes { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<Posts> RestaurantInPost { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Posts> PCreatedBy { get; set; }

        [InverseProperty("Follower")]
        public virtual ICollection<Friendship> Followers { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Friendship> FCreatedBy { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<ChatMessages> Recipient { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<ChatMessages> CCreatedBy { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Likes> LCreatedBy { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Comments> CoCreatedBy { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<Bookings> RestaurantInBooking { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Bookings> BCreatedBy { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<BookingDishes> BDCreatedBy { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Notifications> NRecipient { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Notifications> NCreatedBy { get; set; }

        [InverseProperty("Restaurant")]
        public virtual ICollection<Orders> ORecipient { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<Orders> OCreatedBy { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<OrderDish> OdCreatedBy { get; set; }
        #endregion
    }

    public class Friendship: AuditableEntity
    {
        public virtual ApplicationUser Follower { get; set; }
    }
}
