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
        public int ChatMessageID { get; set; }
        //public int SocialID { get; set; }
        public string Message { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int MessageToID { get; set; }

    }
}
