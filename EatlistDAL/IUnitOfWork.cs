using EatlistDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }
        


        int SaveChanges();
    }
}
