using EatlistDAL.Models;
using EatlistDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EatlistDAL.Repositories
{
    public class DishRepository : Repository<Dishes>, IDishRepository
    {
        public DishRepository(DbContext context, Microsoft.Extensions.Logging.ILogger<dynamic> log) : base(context, log)
        {
        }


    }
}
