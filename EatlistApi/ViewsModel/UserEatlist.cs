using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatListDataService.DataTables;
namespace EatlistApi.Models
{
    public class ProfileUpload//:Upload
    {
        //[Key()]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UploadID { get; set; }

        public Guid UserID { get; set; }

        public string FileUrl { get; set; }

        public bool IsProfile { get; set; }
    }
}
