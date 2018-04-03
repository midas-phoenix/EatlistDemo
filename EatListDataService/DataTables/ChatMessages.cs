using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatListDataService.DataTables
{
    public class ChatMessages
    {

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatMessageID { get; set; }
        public string CreatedBy { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string MessageToID { get; set; }
       
    }
}