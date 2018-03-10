using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatListDataService.Migrations
{
    public partial class Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishID",
                table: "TblBookings");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "tblUploads",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "TableSize",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "BookingStatusID",
                table: "TblBookings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "TblBookingDishes",
                columns: table => new
                {
                    BookingDishID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DishID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBookingDishes", x => x.BookingDishID);
                    table.ForeignKey(
                        name: "FK_TblBookingDishes_TblBookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "TblBookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblBookingDishes_TblDishes_DishID",
                        column: x => x.DishID,
                        principalTable: "TblDishes",
                        principalColumn: "DishesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_BookingStatusID",
                table: "TblBookings",
                column: "BookingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookingDishes_BookingID",
                table: "TblBookingDishes",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookingDishes_DishID",
                table: "TblBookingDishes",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblBookings_TblBookingStatus_BookingStatusID",
                table: "TblBookings",
                column: "BookingStatusID",
                principalTable: "TblBookingStatus",
                principalColumn: "BookingStatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblBookings_TblBookingStatus_BookingStatusID",
                table: "TblBookings");

            migrationBuilder.DropTable(
                name: "TblBookingDishes");

            migrationBuilder.DropIndex(
                name: "IX_TblBookings_BookingStatusID",
                table: "TblBookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "tblUploads",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TableSize",
                table: "TblBookings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TblBookings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingStatusID",
                table: "TblBookings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "TblBookings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
