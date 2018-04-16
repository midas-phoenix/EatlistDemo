using EatlistDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }
        IPostRepository posts { get; }
        IDishRepository Dishes { get; }

        int SaveChanges();
    }
}
