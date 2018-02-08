using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class Dishes7_2_2018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblDishes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TblDishes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsRestaurant",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblDishes_ApplicationUserId",
                table: "TblDishes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_ApplicationUserId",
                table: "TblDishes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblDishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblDishes");

            migrationBuilder.DropColumn(
                name: "IsRestaurant",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "TblDishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
