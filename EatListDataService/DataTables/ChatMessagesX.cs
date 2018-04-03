using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EatListDataService.DataTables
{
    public class ChatMessages
    {

        [Key()]
        public int ChatMessageID { get; set; }
        public string Message { get; set; }
    }
}