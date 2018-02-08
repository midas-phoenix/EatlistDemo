using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class Dishes3_7_2_2018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_Id",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_Id",
                table: "TblDishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblDishes");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblDishes_RestaurantID",
                table: "TblDishes",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_RestaurantID",
                table: "TblDishes",
                column: "RestaurantID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_RestaurantID",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_RestaurantID",
                table: "TblDishes");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "TblDishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblDishes_Id",
                table: "TblDishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDishes_AspNetUsers_Id",
                table: "TblDishes",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
