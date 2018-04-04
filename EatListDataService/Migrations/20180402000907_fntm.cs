using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class fntm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "TblPostsMedia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "TblDishMedia",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profilepicName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "TblPostsMedia");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "TblDishMedia");

            migrationBuilder.DropColumn(
                name: "profilepicName",
                table: "AspNetUsers");
        }
    }
}
