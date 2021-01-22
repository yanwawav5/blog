using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class updatePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "tbl_user");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "tbl_user",
                maxLength: 64,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "tbl_user",
                maxLength: 128,
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "tbl_user");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tbl_user",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
