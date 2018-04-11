using System;
using System.Collections.Generic;
using System.Text;
using EatlistDAL.Repositories;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace EatlistDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        readonly ILogger<dynamic> _log;
        IUserRepository _user;

        public UnitOfWork(ApplicationDbContext context, ILogger<dynamic> log)
        {
            _context = context;
            _log = log;
        }

        public IUserRepository Users {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context, _log);

                return _user;
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
