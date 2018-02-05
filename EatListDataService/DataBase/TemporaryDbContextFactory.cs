using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EatListDataService.DataBase
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //public ApplicationDbContext CreateDbContext(DbContextFactoryOptions options)
        //{
        //    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    builder.UseSqlServer("Server=.;Database=efmigrations2017;Trusted_Connection=True;MultipleActiveResultSets=true",
        //        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));
        //    return new ApplicationDbContext(builder.Options);
        //}

        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=.;Database=Eatlist;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
