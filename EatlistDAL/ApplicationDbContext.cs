﻿using EatlistDAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatlistDAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            var connString = "Data Source=tcp:eatlistserver.database.windows.net,1433;Initial Catalog=Eatlist;User Id=ibrahim@eatlistserver.database.windows.net;Password=Incredible23;"; // Your connection string logic here
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Posts>()
            //            .HasOne(s => s.Restaurants)
            //            .WithMany()
            //            .HasForeignKey(e => e.Id);

        }


        #region "DbSets"
        public DbSet<Bookings> TblBookings { get; set; }

        public DbSet<BookingDishes> TblBookingDishes { get; set; }

        public DbSet<Dishes> TblDishes { get; set; }

        public DbSet<DishMedia> TblDishMedia { get; set; }

        public DbSet<Comments> TblCommennts { get; set; }

        public DbSet<Notifications> tblNotification { get; set; }

        public DbSet<Orders> TblOrders { get; set; }

        public DbSet<OrderDish> TblOrderDish { get; set; }

        public DbSet<Friendship> TblFriendship { get; set; }

        public DbSet<Likes> TblLikes { get; set; }

        public DbSet<Posts> TblPosts { get; set; }

        public DbSet<ChatMessages> ChatMessages { get; set; }

        //public DbSet<Tags> TblTags { get; set; }

        public DbSet<TodoDishes> TodoDishes { get; set; }

        //public DbSet<Upload> tblUploads { get; set; }

        public DbSet<PostsMedia> TblPostsMedia { get; set; }
        #endregion
    }
}
