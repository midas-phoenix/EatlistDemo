﻿// <auto-generated />
using EatlistDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EatlistDAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EatlistDAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("Bio");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Dob");

                    b.Property<DateTime>("Doi");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsRestaurant");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RestaurantName");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("profilepic");

                    b.Property<string>("profilepicName");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EatlistDAL.Models.BookingDishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookingID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("DishID");

                    b.HasKey("Id");

                    b.HasIndex("BookingID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DishID");

                    b.ToTable("TblBookingDishes");
                });

            modelBuilder.Entity("EatlistDAL.Models.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookingStatusID");

                    b.Property<DateTime>("BookingTime");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("RestaurantID");

                    b.Property<int?>("TableSize");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("TblBookings");
                });

            modelBuilder.Entity("EatlistDAL.Models.ChatMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("MessageToID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("MessageToID");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("EatlistDAL.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Image");

                    b.Property<int>("PostID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PostID");

                    b.ToTable("TblCommennts");
                });

            modelBuilder.Entity("EatlistDAL.Models.Dishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("TblDishes");
                });

            modelBuilder.Entity("EatlistDAL.Models.DishMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("DishID");

                    b.Property<string>("FileName");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DishID");

                    b.ToTable("TblDishMedia");
                });

            modelBuilder.Entity("EatlistDAL.Models.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FollowerID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("FollowerID");

                    b.ToTable("TblFriendship");
                });

            modelBuilder.Entity("EatlistDAL.Models.Likes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("PostID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PostID");

                    b.ToTable("TblLikes");
                });

            modelBuilder.Entity("EatlistDAL.Models.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("Recipient");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("tblNotification");
                });

            modelBuilder.Entity("EatlistDAL.Models.OrderDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<int>("DishID");

                    b.Property<int>("OrderID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DishID");

                    b.HasIndex("OrderID");

                    b.ToTable("TblOrderDish");
                });

            modelBuilder.Entity("EatlistDAL.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("DeliveryLocation");

                    b.Property<string>("Note");

                    b.Property<string>("ResturantID");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("TblOrders");
                });

            modelBuilder.Entity("EatlistDAL.Models.Posts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("Dish");

                    b.Property<string>("RestaurantID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Dish");

                    b.HasIndex("RestaurantID");

                    b.ToTable("TblPosts");
                });

            modelBuilder.Entity("EatlistDAL.Models.PostsMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<string>("FileURL");

                    b.Property<int>("PostID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PostID");

                    b.ToTable("TblPostsMedia");
                });

            modelBuilder.Entity("EatlistDAL.Models.TodoDishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("DishID");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DishID");

                    b.ToTable("TodoDishes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EatlistDAL.Models.BookingDishes", b =>
                {
                    b.HasOne("EatlistDAL.Models.Bookings", "Bookings")
                        .WithMany()
                        .HasForeignKey("BookingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.Bookings", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("EatlistDAL.Models.ChatMessages", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("CCreatedBy")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Recipient")
                        .WithMany("Recipient")
                        .HasForeignKey("MessageToID");
                });

            modelBuilder.Entity("EatlistDAL.Models.Comments", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Posts", "Posts")
                        .WithMany()
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.Dishes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Dishes")
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("EatlistDAL.Models.DishMedia", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.Friendship", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("FCreatedBy")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Friends")
                        .WithMany("Friends")
                        .HasForeignKey("FollowerID");
                });

            modelBuilder.Entity("EatlistDAL.Models.Likes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Likes")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Posts", "Posts")
                        .WithMany("Likes")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.Notifications", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("EatlistDAL.Models.OrderDish", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EatlistDAL.Models.Orders", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.Orders", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("EatlistDAL.Models.Posts", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PCreatedBy")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("Dish");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Restaurants")
                        .WithMany("RestaurantInPost")
                        .HasForeignKey("RestaurantID");
                });

            modelBuilder.Entity("EatlistDAL.Models.PostsMedia", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Posts", "Posts")
                        .WithMany("PostsMedia")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EatlistDAL.Models.TodoDishes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dishes")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EatlistDAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
