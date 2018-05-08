using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatlistApi.Models
{
    public class ChatMessages
    {
        public string Message { get; set; }
        public string MessageToID { get; set; }

    }
}
