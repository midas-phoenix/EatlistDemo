using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Models.Interfaces
{
    interface IAuditableEntity
    {
        int Id { get; set; }
        //string CreatedBy { get; set; }
        DateTime DateCreated { get; set; }
    }
}
