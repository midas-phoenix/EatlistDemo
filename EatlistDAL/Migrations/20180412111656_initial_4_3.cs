using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class initial_4_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantsId",
                table: "TblPosts");

            migrationBuilder.DropIndex(
                name: "IX_TblPosts_RestaurantsId",
                table: "TblPosts");

            migrationBuilder.DropColumn(
                name: "RestaurantsId",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "TblPosts",
                newName: "RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "TblPosts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPosts_RestaurantId",
                table: "TblPosts",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantId",
                table: "TblPosts",
                column: "RestaurantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantId",
                table: "TblPosts");

            migrationBuilder.DropIndex(
                name: "IX_TblPosts_RestaurantId",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "TblPosts",
                newName: "RestaurantID");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "TblPosts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantsId",
                table: "TblPosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPosts_RestaurantsId",
                table: "TblPosts",
                column: "RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPosts_AspNetUsers_RestaurantsId",
                table: "TblPosts",
                column: "RestaurantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
