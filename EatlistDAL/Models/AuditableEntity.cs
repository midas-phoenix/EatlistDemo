using EatlistDAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class AuditableEntity : IAuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key()]
        public int Id { get; set; }
        
        public DateTime DateCreated { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
