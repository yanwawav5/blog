using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorNum",
                table: "tbl_comment");

            migrationBuilder.AddColumn<int>(
                name: "CurrentFloorNum",
                table: "tbl_comment",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToFloorNum",
                table: "tbl_comment",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "tbl_blog",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentFloorNum",
                table: "tbl_comment");

            migrationBuilder.DropColumn(
                name: "ToFloorNum",
                table: "tbl_comment");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "tbl_blog");

            migrationBuilder.AddColumn<int>(
                name: "FloorNum",
                table: "tbl_comment",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);
        }
    }
}
