using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_blog_tag_relationship");

            migrationBuilder.AlterColumn<int>(
                name: "Sequence",
                table: "tbl_tag",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11) CHARACTER SET utf8mb4",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "Sequence",
                table: "tbl_category",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11) CHARACTER SET utf8mb4",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "tbl_blog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_blog_tag_relation",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    BlogId = table.Column<string>(maxLength: 36, nullable: false),
                    TagId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blog_tag_relation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_blog_tag_relation");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "tbl_blog");

            migrationBuilder.AlterColumn<string>(
                name: "Sequence",
                table: "tbl_tag",
                type: "varchar(11) CHARACTER SET utf8mb4",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Sequence",
                table: "tbl_category",
                type: "varchar(11) CHARACTER SET utf8mb4",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 11);

            migrationBuilder.CreateTable(
                name: "tbl_blog_tag_relationship",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36) CHARACTER SET utf8mb4", maxLength: 36, nullable: false),
                    BlogId = table.Column<string>(type: "varchar(36) CHARACTER SET utf8mb4", maxLength: 36, nullable: false),
                    TagId = table.Column<string>(type: "varchar(36) CHARACTER SET utf8mb4", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blog_tag_relationship", x => x.Id);
                });
        }
    }
}
