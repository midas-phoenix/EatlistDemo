using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EatListDataService.DataTables
{
    public class Upload
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UploadID { get; set; }

        public Guid UserID { get; set; }

        public string FileUrl { get; set; }

        public bool IsProfile { get; set; }
    }
}
