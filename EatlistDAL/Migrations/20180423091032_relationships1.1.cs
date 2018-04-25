using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class relationships11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_MessageToID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_TblBookings_BookingID",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_TblDishes_DishID",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCommennts_TblPosts_PostID",
                table: "TblCommennts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishMedia_TblDishes_DishID",
                table: "TblDishMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_TblPosts_PostID",
                table: "TblLikes");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "TblLikes",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_TblLikes_PostID",
                table: "TblLikes",
                newName: "IX_TblLikes_PostId");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "TblDishMedia",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishMedia_DishID",
                table: "TblDishMedia",
                newName: "IX_TblDishMedia_DishId");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "TblCommennts",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_TblCommennts_PostID",
                table: "TblCommennts",
                newName: "IX_TblCommennts_PostId");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "TblBookings",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "TblBookingDishes",
                newName: "DishId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "TblBookingDishes",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_DishID",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_BookingID",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_BookingId");

            migrationBuilder.RenameColumn(
                name: "MessageToID",
                table: "ChatMessages",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_MessageToID",
                table: "ChatMessages",
                newName: "IX_ChatMessages_RecipientId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "TblLikes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblLikes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "TblDishMedia",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "TblCommennts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "TblBookingDishes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "TblBookingDishes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_RestaurantId",
                table: "TblBookings",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_RecipientId",
                table: "ChatMessages",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_TblBookings_BookingId",
                table: "TblBookingDishes",
                column: "BookingId",
                principalTable: "TblBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_TblDishes_DishId",
                table: "TblBookingDishes",
                column: "DishId",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_AspNetUsers_RestaurantId",
                table: "TblBookings",
                column: "RestaurantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCommennts_TblPosts_PostId",
                table: "TblCommennts",
                column: "PostId",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishMedia_TblDishes_DishId",
                table: "TblDishMedia",
                column: "DishId",
                principalTable: "TblDishes",
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
                name: "FK_TblLikes_TblPosts_PostId",
                table: "TblLikes",
                column: "PostId",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_RecipientId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_TblBookings_BookingId",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookingDishes_TblDishes_DishId",
                table: "TblBookingDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_AspNetUsers_RestaurantId",
                table: "TblBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCommennts_TblPosts_PostId",
                table: "TblCommennts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDishMedia_TblDishes_DishId",
                table: "TblDishMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_AspNetUsers_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_TblPosts_PostId",
                table: "TblLikes");

            migrationBuilder.DropIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropIndex(
                name: "IX_TblBookings_RestaurantId",
                table: "TblBookings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "TblLikes",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_TblLikes_PostId",
                table: "TblLikes",
                newName: "IX_TblLikes_PostID");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "TblDishMedia",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_TblDishMedia_DishId",
                table: "TblDishMedia",
                newName: "IX_TblDishMedia_DishID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "TblCommennts",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_TblCommennts_PostId",
                table: "TblCommennts",
                newName: "IX_TblCommennts_PostID");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "TblBookings",
                newName: "RestaurantID");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "TblBookingDishes",
                newName: "DishID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TblBookingDishes",
                newName: "BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_DishId",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_DishID");

            migrationBuilder.RenameIndex(
                name: "IX_TblBookingDishes_BookingId",
                table: "TblBookingDishes",
                newName: "IX_TblBookingDishes_BookingID");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "ChatMessages",
                newName: "MessageToID");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_RecipientId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_MessageToID");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "TblLikes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishID",
                table: "TblDishMedia",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "TblCommennts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishID",
                table: "TblBookingDishes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "TblBookingDishes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_MessageToID",
                table: "ChatMessages",
                column: "MessageToID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_TblBookings_BookingID",
                table: "TblBookingDishes",
                column: "BookingID",
                principalTable: "TblBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookingDishes_TblDishes_DishID",
                table: "TblBookingDishes",
                column: "DishID",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCommennts_TblPosts_PostID",
                table: "TblCommennts",
                column: "PostID",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishMedia_TblDishes_DishID",
                table: "TblDishMedia",
                column: "DishID",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblLikes_TblPosts_PostID",
                table: "TblLikes",
                column: "PostID",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
