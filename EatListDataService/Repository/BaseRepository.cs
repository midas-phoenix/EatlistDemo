using EatListDataService.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
    public class BaseRepository 
    {
        #region "Declarations and Constructors"
        public static ApplicationDbContext entities=new ApplicationDbContext();
        public ILogger<dynamic> _log { get; set; }

        //public BaseRepository(ApplicationDbContext context,ILogger<dynamic> log)
        //{
        //    _log = log;
        //}
        ////private List<Posts> entities;
        ////public string errorMessage = string.Empty;

        public BaseRepository()
        {
        }
        //public BaseRepository(ApplicationDbContext context)
        //{
        //    //this.context = context;
        //    entities = context;
        //}
        #endregion

        #region "Base"



        #endregion
        #region "meta"
        public void SaveChange()
        {
            entities.SaveChanges();
        }
        #endregion
    }
}

