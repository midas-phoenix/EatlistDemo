using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistDAL.Models
{
    public class Posts : AuditableEntity
    {
        public string Caption { get; set; }

        public virtual Dishes Dish { get; set; }

        public virtual ICollection<PostsMedia> PostsMedia { get; set; }

        [InverseProperty("Post")]
        public virtual ICollection<Likes> Likes { get; set; }

        [InverseProperty("Post")]
        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ApplicationUser Restaurant { get; set; }
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
        public virtual Posts Post { get; set; }
    }

    public class Comments : AuditableEntity
    {
        public string Content { get; set; }
        public string Image { get; set; }

        public virtual Posts Post { get; set; }
    }
}
