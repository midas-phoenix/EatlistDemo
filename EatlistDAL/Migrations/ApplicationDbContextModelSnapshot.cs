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

                    b.Property<int?>("BookingId");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DishId");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DishId");

                    b.ToTable("TblBookingDishes");
                });

            modelBuilder.Entity("EatlistDAL.Models.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookingStatusID");

                    b.Property<DateTime>("BookingTime");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("RestaurantId");

                    b.Property<int?>("TableSize");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RestaurantId");

                    b.ToTable("TblBookings");
                });

            modelBuilder.Entity("EatlistDAL.Models.ChatMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("RecipientId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RecipientId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("EatlistDAL.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Image");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PostId");

                    b.ToTable("TblCommennts");
                });

            modelBuilder.Entity("EatlistDAL.Models.Dishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("TblDishes");
                });

            modelBuilder.Entity("EatlistDAL.Models.DishMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DishId");

                    b.Property<string>("FileName");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DishId");

                    b.ToTable("TblDishMedia");
                });

            modelBuilder.Entity("EatlistDAL.Models.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FollowerId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FollowerId");

                    b.ToTable("TblFriendship");
                });

            modelBuilder.Entity("EatlistDAL.Models.Likes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PostId");

                    b.ToTable("TblLikes");
                });

            modelBuilder.Entity("EatlistDAL.Models.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("RecipientId");

                    b.Property<string>("Source");

                    b.Property<bool>("seen");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RecipientId");

                    b.ToTable("tblNotification");
                });

            modelBuilder.Entity("EatlistDAL.Models.OrderDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<int?>("DishId");

                    b.Property<int?>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("TblOrderDish");
                });

            modelBuilder.Entity("EatlistDAL.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("DeliveryLocation");

                    b.Property<string>("Note");

                    b.Property<string>("RestaurantId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RestaurantId");

                    b.ToTable("TblOrders");
                });

            modelBuilder.Entity("EatlistDAL.Models.Posts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DishId");

                    b.Property<string>("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DishId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("TblPosts");
                });

            modelBuilder.Entity("EatlistDAL.Models.PostsMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<string>("FileURL");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PostId");

                    b.ToTable("TblPostsMedia");
                });

            modelBuilder.Entity("EatlistDAL.Models.TodoDishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DishId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DishId");

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
                    b.HasOne("EatlistDAL.Models.Bookings", "Booking")
                        .WithMany("BookingDishes")
                        .HasForeignKey("BookingId");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("BDCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dish")
                        .WithMany("BookingDishes")
                        .HasForeignKey("DishId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Bookings", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("BCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Restaurant")
                        .WithMany("RestaurantInBooking")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("EatlistDAL.Models.ChatMessages", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("CCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Recipient")
                        .WithMany("Recipient")
                        .HasForeignKey("RecipientId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Comments", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("CoCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Posts", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Dishes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("Dishes")
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("EatlistDAL.Models.DishMedia", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dish")
                        .WithMany("DishMedia")
                        .HasForeignKey("DishId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Friendship", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("FCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Likes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("LCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Posts", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Notifications", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("NCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Recipient")
                        .WithMany("NRecipient")
                        .HasForeignKey("RecipientId");
                });

            modelBuilder.Entity("EatlistDAL.Models.OrderDish", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("OdCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dish")
                        .WithMany("OrderDish")
                        .HasForeignKey("DishId");

                    b.HasOne("EatlistDAL.Models.Orders", "Order")
                        .WithMany("OrderDish")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Orders", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("OCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Restaurant")
                        .WithMany("ORecipient")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("EatlistDAL.Models.Posts", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany("PCreatedBy")
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dish")
                        .WithMany("Post")
                        .HasForeignKey("DishId");

                    b.HasOne("EatlistDAL.Models.ApplicationUser", "Restaurant")
                        .WithMany("RestaurantInPost")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("EatlistDAL.Models.PostsMedia", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Posts", "Post")
                        .WithMany("PostsMedia")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("EatlistDAL.Models.TodoDishes", b =>
                {
                    b.HasOne("EatlistDAL.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("EatlistDAL.Models.Dishes", "Dish")
                        .WithMany("TodoDishes")
                        .HasForeignKey("DishId");
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
