using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class updateUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "tbl_user",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "tbl_user");
        }
    }
}
