using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatListDataService.DataTables
{
    public class Notifications
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key()]
        public int NotificationID { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Recipient { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
