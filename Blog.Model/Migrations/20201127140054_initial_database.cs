using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Model.Migrations
{
    public partial class initial_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_blog",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    ContentId = table.Column<string>(maxLength: 36, nullable: false),
                    CategoryId = table.Column<string>(maxLength: 36, nullable: false),
                    PicUrl = table.Column<string>(maxLength: 36, nullable: false),
                    ViewTimes = table.Column<int>(maxLength: 11, nullable: false),
                    LikeTimes = table.Column<int>(maxLength: 11, nullable: false),
                    State = table.Column<string>(maxLength: 1, nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    DeleteAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_blog_content",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Content = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blog_content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_blog_tag_relationship",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    BlogId = table.Column<string>(maxLength: 36, nullable: false),
                    TagId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blog_tag_relationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Sequence = table.Column<string>(maxLength: 11, nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_comment",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    BlogId = table.Column<string>(maxLength: 36, nullable: false),
                    Content = table.Column<string>(maxLength: 36, nullable: false),
                    From = table.Column<string>(maxLength: 36, nullable: false),
                    To = table.Column<string>(maxLength: 36, nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    LikeTimes = table.Column<int>(maxLength: 11, nullable: false),
                    FloorNum = table.Column<int>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_file",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Path = table.Column<string>(maxLength: 255, nullable: false),
                    ExtName = table.Column<string>(maxLength: 255, nullable: false),
                    Size = table.Column<double>(nullable: false),
                    UploadAt = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_file", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tag",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Sequence = table.Column<string>(maxLength: 11, nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    RegisterAt = table.Column<DateTime>(nullable: false),
                    LastLoginAt = table.Column<DateTime>(nullable: false),
                    LastLoginAddr = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_blog");

            migrationBuilder.DropTable(
                name: "tbl_blog_content");

            migrationBuilder.DropTable(
                name: "tbl_blog_tag_relationship");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropTable(
                name: "tbl_comment");

            migrationBuilder.DropTable(
                name: "tbl_file");

            migrationBuilder.DropTable(
                name: "tbl_tag");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
