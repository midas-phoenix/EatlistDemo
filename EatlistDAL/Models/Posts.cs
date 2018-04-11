using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistDAL.Models
{
    public class Posts : AuditableEntity
    {
        public string Caption { get; set; }

        [ForeignKey("Dishes")]
        public int? Dish { get; set; }

        [ForeignKey("Restaurants")]
        public string RestaurantID { get; set; }
        
        public virtual Dishes Dishes { get; set; }
        public virtual ICollection<PostsMedia> PostsMedia { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ApplicationUser Restaurants { get; set; }
    }

    public class PostsMedia : AuditableEntity
    {
        [ForeignKey("Posts")]
        public int PostID { get; set; }

        public string FileURL { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public virtual Posts Posts { get; set; }
    }

    public class Likes: AuditableEntity
    {
        [ForeignKey("Posts")]
        public int PostID { get; set; }

        public virtual Posts Posts { get; set; }
    }

    public class Comments : AuditableEntity
    {
        [ForeignKey("Posts")]
        public int PostID { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public virtual Posts Posts { get; set; }
    }
}
