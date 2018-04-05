using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class bookingstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_TblBookingStatus_BookingStatusID",
                table: "TblBookings");

            migrationBuilder.DropTable(
                name: "TblBookingStatus");

            migrationBuilder.DropIndex(
                name: "IX_TblBookings_BookingStatusID",
                table: "TblBookings");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "tblNotification",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageToID",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblOrderDish",
                columns: table => new
                {
                    OrderDishID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DishID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrderDish", x => x.OrderDishID);
                });

            migrationBuilder.CreateTable(
                name: "TblOrders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DeliveryLocation = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ResturantID = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrders", x => x.OrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOrderDish");

            migrationBuilder.DropTable(
                name: "TblOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "MessageToID",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "tblNotification",
                newName: "Source");

            migrationBuilder.CreateTable(
                name: "TblBookingStatus",
                columns: table => new
                {
                    BookingStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBookingStatus", x => x.BookingStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_BookingStatusID",
                table: "TblBookings",
                column: "BookingStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_TblBookingStatus_BookingStatusID",
                table: "TblBookings",
                column: "BookingStatusID",
                principalTable: "TblBookingStatus",
                principalColumn: "BookingStatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
