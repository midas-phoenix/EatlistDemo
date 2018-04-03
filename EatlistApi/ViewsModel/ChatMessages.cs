using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistApi.Models
{
    public class ChatMessages
    {
     [Key()]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ChatMessageID { get; set; }
        //public string MessageSenderID { get; set; }
        public string Message { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime DateCreated { get; set; }
        public string MessageToID { get; set; }

    }
}
