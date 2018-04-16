using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class initial_4_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ApplicationUserId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_ApplicationUserId",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_AspNetUsers_ApplicationUserId",
                table: "TblBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCommennts_AspNetUsers_ApplicationUserId",
                table: "TblCommennts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_ApplicationUserId",
                table: "TblDishMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TblFriendship_AspNetUsers_ApplicationUserId",
                table: "TblFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_AspNetUsers_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNotification_AspNetUsers_ApplicationUserId",
                table: "tblNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_ApplicationUserId",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_AspNetUsers_ApplicationUserId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_ApplicationUserId",
                table: "TblPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_ApplicationUserId",
                table: "TblPostsMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDishes_AspNetUsers_ApplicationUserId",
                table: "TodoDishes");

            migrationBuilder.DropIndex(
                name: "IX_TodoDishes_ApplicationUserId",
                table: "TodoDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblPostsMedia_ApplicationUserId",
                table: "TblPostsMedia");

            migrationBuilder.DropIndex(
                name: "IX_TblPosts_ApplicationUserId",
                table: "TblPosts");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_ApplicationUserId",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_TblOrderDish_ApplicationUserId",
                table: "TblOrderDish");

            migrationBuilder.DropIndex(
                name: "IX_tblNotification_ApplicationUserId",
                table: "tblNotification");

            migrationBuilder.DropIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropIndex(
                name: "IX_TblFriendship_ApplicationUserId",
                table: "TblFriendship");

            migrationBuilder.DropIndex(
                name: "IX_TblDishMedia_ApplicationUserId",
                table: "TblDishMedia");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblCommennts_ApplicationUserId",
                table: "TblCommennts");

            migrationBuilder.DropIndex(
                name: "IX_TblBookings_ApplicationUserId",
                table: "TblBookings");

            migrationBuilder.DropIndex(
                name: "IX_TblBookingDishes_ApplicationUserId",
                table: "TblBookingDishes");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ApplicationUserId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TodoDishes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblPostsMedia");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblOrders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblOrderDish");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "tblNotification");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblFriendship");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblDishMedia");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblCommennts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblBookings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblBookingDishes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ChatMessages");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblPostsMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblPosts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblOrderDish",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblNotification",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblLikes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblFriendship",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblDishMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblCommennts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblBookingDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ChatMessages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoDishes_CreatedBy",
                table: "TodoDishes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblPostsMedia_CreatedBy",
                table: "TblPostsMedia",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblPosts_CreatedBy",
                table: "TblPosts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_CreatedBy",
                table: "TblOrders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrderDish_CreatedBy",
                table: "TblOrderDish",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tblNotification_CreatedBy",
                table: "tblNotification",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblLikes_CreatedBy",
                table: "TblLikes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblFriendship_CreatedBy",
                table: "TblFriendship",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblDishMedia_CreatedBy",
                table: "TblDishMedia",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblDishes_CreatedBy",
                table: "TblDishes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommennts_CreatedBy",
                table: "TblCommennts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_CreatedBy",
                table: "TblBookings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookingDishes_CreatedBy",
                table: "TblBookingDishes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_CreatedBy",
                table: "ChatMessages",
                column: "CreatedBy");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_TodoDishes_CreatedBy",
                table: "TodoDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblPostsMedia_CreatedBy",
                table: "TblPostsMedia");

            migrationBuilder.DropIndex(
                name: "IX_TblPosts_CreatedBy",
                table: "TblPosts");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_CreatedBy",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_TblOrderDish_CreatedBy",
                table: "TblOrderDish");

            migrationBuilder.DropIndex(
                name: "IX_tblNotification_CreatedBy",
                table: "tblNotification");

            migrationBuilder.DropIndex(
                name: "IX_TblLikes_CreatedBy",
                table: "TblLikes");

            migrationBuilder.DropIndex(
                name: "IX_TblFriendship_CreatedBy",
                table: "TblFriendship");

            migrationBuilder.DropIndex(
                name: "IX_TblDishMedia_CreatedBy",
                table: "TblDishMedia");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_CreatedBy",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblCommennts_CreatedBy",
                table: "TblCommennts");

            migrationBuilder.DropIndex(
                name: "IX_TblBookings_CreatedBy",
                table: "TblBookings");

            migrationBuilder.DropIndex(
                name: "IX_TblBookingDishes_CreatedBy",
                table: "TblBookingDishes");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_CreatedBy",
                table: "ChatMessages");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TodoDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TodoDishes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblPostsMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblPostsMedia",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblPosts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblPosts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblOrders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblOrderDish",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblOrderDish",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblNotification",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "tblNotification",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblLikes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblLikes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblFriendship",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblFriendship",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblDishMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblDishMedia",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblDishes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblCommennts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblCommennts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblBookings",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TblBookingDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblBookingDishes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ChatMessages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoDishes_ApplicationUserId",
                table: "TodoDishes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPostsMedia_ApplicationUserId",
                table: "TblPostsMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPosts_ApplicationUserId",
                table: "TblPosts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_ApplicationUserId",
                table: "TblOrders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrderDish_ApplicationUserId",
                table: "TblOrderDish",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNotification_ApplicationUserId",
                table: "tblNotification",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFriendship_ApplicationUserId",
                table: "TblFriendship",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDishMedia_ApplicationUserId",
                table: "TblDishMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDishes_ApplicationUserId",
                table: "TblDishes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommennts_ApplicationUserId",
                table: "TblCommennts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_ApplicationUserId",
                table: "TblBookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookingDishes_ApplicationUserId",
                table: "TblBookingDishes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ApplicationUserId",
                table: "ChatMessages",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ApplicationUserId",
                table: "ChatMessages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_AspNetUsers_ApplicationUserId",
                table: "TblBookingDishes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_AspNetUsers_ApplicationUserId",
                table: "TblBookings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCommennts_AspNetUsers_ApplicationUserId",
                table: "TblCommennts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_ApplicationUserId",
                table: "TblDishes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishMedia_AspNetUsers_ApplicationUserId",
                table: "TblDishMedia",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblFriendship_AspNetUsers_ApplicationUserId",
                table: "TblFriendship",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblLikes_AspNetUsers_ApplicationUserId",
                table: "TblLikes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNotification_AspNetUsers_ApplicationUserId",
                table: "tblNotification",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_AspNetUsers_ApplicationUserId",
                table: "TblOrderDish",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_AspNetUsers_ApplicationUserId",
                table: "TblOrders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_ApplicationUserId",
                table: "TblPosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPostsMedia_AspNetUsers_ApplicationUserId",
                table: "TblPostsMedia",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDishes_AspNetUsers_ApplicationUserId",
                table: "TodoDishes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
