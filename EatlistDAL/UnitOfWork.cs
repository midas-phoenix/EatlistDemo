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
        IPostRepository _post;
        IDishRepository _dishes;

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

        public IPostRepository posts {
            get
            {
                if (_post == null)
                    _post = new PostRepository(_context, _log);

                return _post;
            }
        }

        public IDishRepository Dishes
        {
            get {
                if (_dishes == null)
                    _dishes = new DishRepository(_context, _log);

                return _dishes;
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
