using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class initial_4_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantID",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "TblPosts",
                newName: "RestaurantsId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_RestaurantID",
                table: "TblPosts",
                newName: "IX_TblPosts_RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantsId",
                table: "TblPosts",
                column: "RestaurantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantsId",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "RestaurantsId",
                table: "TblPosts",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_TblPosts_RestaurantsId",
                table: "TblPosts",
                newName: "IX_TblPosts_RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantID",
                table: "TblPosts",
                column: "RestaurantID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
