using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class updateFieldLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PicUrl",
                table: "tbl_blog",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36) CHARACTER SET utf8mb4",
                oldMaxLength: 36);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PicUrl",
                table: "tbl_blog",
                type: "varchar(36) CHARACTER SET utf8mb4",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
