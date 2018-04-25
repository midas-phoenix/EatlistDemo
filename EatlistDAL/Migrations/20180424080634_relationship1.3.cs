using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class relationship13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CreatedBy",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_CreatedBy",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_AspNetUsers_CreatedBy",
                table: "TblBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCommennts_AspNetUsers_CreatedBy",
                table: "TblCommennts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_CreatedBy",
                table: "TblDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_CreatedBy",
                table: "TblDishMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TblFriendship_AspNetUsers_CreatedBy",
                table: "TblFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_AspNetUsers_CreatedBy",
                table: "TblLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNotification_AspNetUsers_CreatedBy",
                table: "tblNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_CreatedBy",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_AspNetUsers_CreatedBy",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_CreatedBy",
                table: "TblPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_CreatedBy",
                table: "TblPostsMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDishes_AspNetUsers_CreatedBy",
                table: "TodoDishes");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TodoDishes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TodoDishes_CreatedBy",
                table: "TodoDishes",
                newName: "IX_TodoDishes_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblPostsMedia",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblPostsMedia_CreatedBy",
                table: "TblPostsMedia",
                newName: "IX_TblPostsMedia_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblPosts",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_CreatedBy",
                table: "TblPosts",
                newName: "IX_TblPosts_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblOrders",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrders_CreatedBy",
                table: "TblOrders",
                newName: "IX_TblOrders_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblOrderDish",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_CreatedBy",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "tblNotification",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_tblNotification_CreatedBy",
                table: "tblNotification",
                newName: "IX_tblNotification_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblLikes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblLikes_CreatedBy",
                table: "TblLikes",
                newName: "IX_TblLikes_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblFriendship",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblFriendship_CreatedBy",
                table: "TblFriendship",
                newName: "IX_TblFriendship_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblDishMedia",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishMedia_CreatedBy",
                table: "TblDishMedia",
                newName: "IX_TblDishMedia_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblDishes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishes_CreatedBy",
                table: "TblDishes",
                newName: "IX_TblDishes_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblCommennts",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblCommennts_CreatedBy",
                table: "TblCommennts",
                newName: "IX_TblCommennts_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblBookings",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookings_CreatedBy",
                table: "TblBookings",
                newName: "IX_TblBookings_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TblBookingDishes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_CreatedBy",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_CreatedById");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ChatMessages",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_CreatedBy",
                table: "ChatMessages",
                newName: "IX_ChatMessages_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CreatedById",
                table: "ChatMessages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_CreatedById",
                table: "TblBookingDishes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_AspNetUsers_CreatedById",
                table: "TblBookings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCommennts_AspNetUsers_CreatedById",
                table: "TblCommennts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_CreatedById",
                table: "TblDishes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_CreatedById",
                table: "TblDishMedia",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblFriendship_AspNetUsers_CreatedById",
                table: "TblFriendship",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblLikes_AspNetUsers_CreatedById",
                table: "TblLikes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNotification_AspNetUsers_CreatedById",
                table: "tblNotification",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_CreatedById",
                table: "TblOrderDish",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_AspNetUsers_CreatedById",
                table: "TblOrders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_CreatedById",
                table: "TblPosts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_CreatedById",
                table: "TblPostsMedia",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDishes_AspNetUsers_CreatedById",
                table: "TodoDishes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CreatedById",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_CreatedById",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_AspNetUsers_CreatedById",
                table: "TblBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCommennts_AspNetUsers_CreatedById",
                table: "TblCommennts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_CreatedById",
                table: "TblDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_CreatedById",
                table: "TblDishMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TblFriendship_AspNetUsers_CreatedById",
                table: "TblFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_AspNetUsers_CreatedById",
                table: "TblLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNotification_AspNetUsers_CreatedById",
                table: "tblNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_CreatedById",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_AspNetUsers_CreatedById",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_CreatedById",
                table: "TblPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_CreatedById",
                table: "TblPostsMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDishes_AspNetUsers_CreatedById",
                table: "TodoDishes");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TodoDishes",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TodoDishes_CreatedById",
                table: "TodoDishes",
                newName: "IX_TodoDishes_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblPostsMedia",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblPostsMedia_CreatedById",
                table: "TblPostsMedia",
                newName: "IX_TblPostsMedia_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblPosts",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_CreatedById",
                table: "TblPosts",
                newName: "IX_TblPosts_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblOrders",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrders_CreatedById",
                table: "TblOrders",
                newName: "IX_TblOrders_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblOrderDish",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_CreatedById",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "tblNotification",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_tblNotification_CreatedById",
                table: "tblNotification",
                newName: "IX_tblNotification_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblLikes",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblLikes_CreatedById",
                table: "TblLikes",
                newName: "IX_TblLikes_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblFriendship",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblFriendship_CreatedById",
                table: "TblFriendship",
                newName: "IX_TblFriendship_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblDishMedia",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishMedia_CreatedById",
                table: "TblDishMedia",
                newName: "IX_TblDishMedia_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblDishes",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishes_CreatedById",
                table: "TblDishes",
                newName: "IX_TblDishes_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblCommennts",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblCommennts_CreatedById",
                table: "TblCommennts",
                newName: "IX_TblCommennts_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblBookings",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookings_CreatedById",
                table: "TblBookings",
                newName: "IX_TblBookings_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TblBookingDishes",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_CreatedById",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "ChatMessages",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_CreatedById",
                table: "ChatMessages",
                newName: "IX_ChatMessages_CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CreatedBy",
                table: "ChatMessages",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_CreatedBy",
                table: "TblBookingDishes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_AspNetUsers_CreatedBy",
                table: "TblBookings",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCommennts_AspNetUsers_CreatedBy",
                table: "TblCommennts",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_CreatedBy",
                table: "TblDishes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_CreatedBy",
                table: "TblDishMedia",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblFriendship_AspNetUsers_CreatedBy",
                table: "TblFriendship",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblLikes_AspNetUsers_CreatedBy",
                table: "TblLikes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNotification_AspNetUsers_CreatedBy",
                table: "tblNotification",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_CreatedBy",
                table: "TblOrderDish",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_AspNetUsers_CreatedBy",
                table: "TblOrders",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_CreatedBy",
                table: "TblPosts",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_CreatedBy",
                table: "TblPostsMedia",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDishes_AspNetUsers_CreatedBy",
                table: "TodoDishes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
