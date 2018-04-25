using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EatlistDAL.Migrations
{
    public partial class relationship14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPostsMedia_TblPosts_PostID",
                table: "TblPostsMedia");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "TblPostsMedia",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_TblPostsMedia_PostID",
                table: "TblPostsMedia",
                newName: "IX_TblPostsMedia_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "TblPostsMedia",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TblPostsMedia_TblPosts_PostId",
                table: "TblPostsMedia",
                column: "PostId",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPostsMedia_TblPosts_PostId",
                table: "TblPostsMedia");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "TblPostsMedia",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_TblPostsMedia_PostId",
                table: "TblPostsMedia",
                newName: "IX_TblPostsMedia_PostID");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "TblPostsMedia",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPostsMedia_TblPosts_PostID",
                table: "TblPostsMedia",
                column: "PostID",
                principalTable: "TblPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
