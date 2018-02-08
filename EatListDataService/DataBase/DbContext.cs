﻿using EatListDataService.DataTables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatListDataService.DataBase
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region "constructors"

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
        #endregion

        #region "DbSets"
        public DbSet<Bookings> TblBookings { get; set; }

        public DbSet<Dishes> TblDishes { get; set; }

        public DbSet<Comments> TblCommennts { get; set; }

        public DbSet<BookingStatus> TblBookingStatus { get; set; }

        public DbSet<Friendship> TblFriendship { get; set; }

        public DbSet<Likes> TblLikes { get; set; }

        public DbSet<Posts> TblPosts { get; set; }

        public DbSet<ChatMessages> ChatMessages { get; set; }

        public DbSet<Tags> TblTags { get; set; }

        public DbSet<ToDoMeals> TblToDoMeals { get; set; }

        public DbSet<Notifications> tblNotification { get; set; }

        public DbSet<Upload> tblUploads { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "Server=DEV-SERVER\\SQLEXPRESS;Database=Eatlist;User ID=bigdata;pwd=p@33word;MultipleActiveResultSets=true"; // Your connection string logic here
            //optionsBuilder.UseSqlite("Data Source=blog.db");
            optionsBuilder.UseSqlServer(connString);
        }
    }
}