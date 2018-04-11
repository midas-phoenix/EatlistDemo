using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL.Repositories
{
    public class CommentRepository : Repository<Comments>, ICommentRepository
    {
        public CommentRepository(DbContext context, ILogger<dynamic> log) : base(context, log)
        {
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public dynamic FetchComment(int PostID)
        {
            throw new NotImplementedException();
        }
    }
}
