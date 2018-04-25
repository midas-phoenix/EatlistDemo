using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatlistDAL.Models
{
    public class Notifications: AuditableEntity
    {
        public string Message { get; set; }
        public bool seen { get; set; }
        public string Source { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
    }

    public class ChatMessages : AuditableEntity
    {
        public string Message { get; set; }
        
        public virtual ApplicationUser Recipient { get; set; }
    }
}
