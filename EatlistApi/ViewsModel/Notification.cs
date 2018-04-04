using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatlistApi.ViewsModel
{
    public class Notification
    {
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Recipient { get; set; }
    }
}
