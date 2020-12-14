using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class addIconFontClassField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconFontClass",
                table: "tbl_tag",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconFontClass",
                table: "tbl_tag");
        }
    }
}
