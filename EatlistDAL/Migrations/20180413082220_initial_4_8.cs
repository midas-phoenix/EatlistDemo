using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class initial_4_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_TblDishes_Dish",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "Dish",
                table: "TblPosts",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_Dish",
                table: "TblPosts",
                newName: "IX_TblPosts_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_TblDishes_DishId",
                table: "TblPosts",
                column: "DishId",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_TblDishes_DishId",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "TblPosts",
                newName: "Dish");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_DishId",
                table: "TblPosts",
                newName: "IX_TblPosts_Dish");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_TblDishes_Dish",
                table: "TblPosts",
                column: "Dish",
                principalTable: "TblDishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
