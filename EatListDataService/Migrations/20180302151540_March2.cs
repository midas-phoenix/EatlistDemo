using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class March2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblDishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblDishMedia",
                columns: table => new
                {
                    DishMediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DishID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDishMedia", x => x.DishMediaID);
                    table.ForeignKey(
                        name: "FK_TblDishMedia_TblDishes_DishID",
                        column: x => x.DishID,
                        principalTable: "TblDishes",
                        principalColumn: "DishesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblDishMedia_DishID",
                table: "TblDishMedia",
                column: "DishID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblDishMedia");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblDishes");
        }
    }
}
