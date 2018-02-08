using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class Dishes2_7_2_2018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TblDishes",
                nullable: true,
                oldClrType: typeof(Guid));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDishes_AspNetUsers_Id",
                table: "TblDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblDishes_Id",
                table: "TblDishes");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblDishes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblDishes",
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
    }
}
