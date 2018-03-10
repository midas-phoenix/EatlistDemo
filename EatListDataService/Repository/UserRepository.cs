using EatListDataService.DataBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatListDataService.Repository
{
    public class UserRepository
    {
        #region "Declarations and Constructors"
        private readonly ApplicationDbContext entities;
        readonly ILogger _log;

        public UserRepository(ILogger log)
        {
            _log = log;
        }
        //private List<Posts> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            //this.context = context;
            entities = context;
        }
        #endregion

        #region 'Users'
        public ApplicationUser Get(string UserID)
        {
            return entities.Users.Where(d => d.Id == UserID).FirstOrDefault();
        }
        #endregion

        #region "meta"
        private void SaveChange()
        {
            entities.SaveChanges();
        }
        #endregion
    }
}
