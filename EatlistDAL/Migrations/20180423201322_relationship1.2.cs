using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class relationship12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFriendship_AspNetUsers_FollowerID",
                table: "TblFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_TblLikes_AspNetUsers_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_TblDishes_DishID",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_TblOrders_OrderID",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDishes_TblDishes_DishID",
                table: "TodoDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblLikes");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "TodoDishes",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoDishes_DishID",
                table: "TodoDishes",
                newName: "IX_TodoDishes_DishId");

            migrationBuilder.RenameColumn(
                name: "ResturantID",
                table: "TblOrders",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "TblOrderDish",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "TblOrderDish",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_OrderID",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_DishID",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_DishId");

            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "tblNotification",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "FollowerID",
                table: "TblFriendship",
                newName: "FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_TblFriendship_FollowerID",
                table: "TblFriendship",
                newName: "IX_TblFriendship_FollowerId");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "TodoDishes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "TblOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "TblOrderDish",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "TblOrderDish",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "tblNotification",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "seen",
                table: "tblNotification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TblOrders_RestaurantId",
                table: "TblOrders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNotification_RecipientId",
                table: "tblNotification",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFriendship_AspNetUsers_FollowerId",
                table: "TblFriendship",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNotification_AspNetUsers_RecipientId",
                table: "tblNotification",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_TblDishes_DishId",
                table: "TblOrderDish",
                column: "DishId",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_TblOrders_OrderId",
                table: "TblOrderDish",
                column: "OrderId",
                principalTable: "TblOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrders_AspNetUsers_RestaurantId",
                table: "TblOrders",
                column: "RestaurantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDishes_TblDishes_DishId",
                table: "TodoDishes",
                column: "DishId",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFriendship_AspNetUsers_FollowerId",
                table: "TblFriendship");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNotification_AspNetUsers_RecipientId",
                table: "tblNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_TblDishes_DishId",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrderDish_TblOrders_OrderId",
                table: "TblOrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOrders_AspNetUsers_RestaurantId",
                table: "TblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDishes_TblDishes_DishId",
                table: "TodoDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblOrders_RestaurantId",
                table: "TblOrders");

            migrationBuilder.DropIndex(
                name: "IX_tblNotification_RecipientId",
                table: "tblNotification");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "tblNotification");

            migrationBuilder.DropColumn(
                name: "seen",
                table: "tblNotification");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "TodoDishes",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_TodoDishes_DishId",
                table: "TodoDishes",
                newName: "IX_TodoDishes_DishID");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "TblOrders",
                newName: "ResturantID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "TblOrderDish",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "TblOrderDish",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_OrderId",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_TblOrderDish_DishId",
                table: "TblOrderDish",
                newName: "IX_TblOrderDish_DishID");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "tblNotification",
                newName: "Recipient");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "TblFriendship",
                newName: "FollowerID");

            migrationBuilder.RenameIndex(
                name: "IX_TblFriendship_FollowerId",
                table: "TblFriendship",
                newName: "IX_TblFriendship_FollowerID");

            migrationBuilder.AlterColumn<int>(
                name: "DishID",
                table: "TodoDishes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResturantID",
                table: "TblOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "TblOrderDish",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishID",
                table: "TblOrderDish",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblLikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblLikes_ApplicationUserId",
                table: "TblLikes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFriendship_AspNetUsers_FollowerID",
                table: "TblFriendship",
                column: "FollowerID",
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
                name: "FK_TblOrderDish_TblDishes_DishID",
                table: "TblOrderDish",
                column: "DishID",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOrderDish_TblOrders_OrderID",
                table: "TblOrderDish",
                column: "OrderID",
                principalTable: "TblOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDishes_TblDishes_DishID",
                table: "TodoDishes",
                column: "DishID",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
