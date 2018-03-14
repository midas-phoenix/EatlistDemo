using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileURL",
                table: "TblPosts",
                newName: "RestaurantID");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "TblPosts",
                newName: "Caption");

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "TblPosts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblPostsMedia",
                columns: table => new
                {
                    PostMediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileType = table.Column<string>(nullable: true),
                    FileURL = table.Column<string>(nullable: true),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPostsMedia", x => x.PostMediaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPostsMedia");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "TblPosts");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "TblPosts",
                newName: "FileURL");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "TblPosts",
                newName: "FileType");
        }
    }
}
