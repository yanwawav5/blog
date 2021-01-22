﻿// <auto-generated />
using System;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Model.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20210122025920_updatePassword")]
    partial class updatePassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Blog.Model.tbl_blog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ContentId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LikeTimes")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.Property<string>("PicUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("PublishAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Remark")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4")
                        .HasMaxLength(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ViewTimes")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("tbl_blog");
                });

            modelBuilder.Entity("Blog.Model.tbl_blog_content", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(5000);

                    b.HasKey("Id");

                    b.ToTable("tbl_blog_content");
                });

            modelBuilder.Entity("Blog.Model.tbl_blog_tag_relation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("BlogId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("TagId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.ToTable("tbl_blog_tag_relation");
                });

            modelBuilder.Entity("Blog.Model.tbl_category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Remark")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("Sequence")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("Blog.Model.tbl_comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("BlogId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CurrentFloorNum")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<int>("LikeTimes")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.Property<string>("To")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<int?>("ToFloorNum")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("tbl_comment");
                });

            modelBuilder.Entity("Blog.Model.tbl_file", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ExtName")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<double>("Size")
                        .HasColumnType("double");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UploadAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("tbl_file");
                });

            modelBuilder.Entity("Blog.Model.tbl_tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("IconFontClass")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Remark")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("Sequence")
                        .HasColumnType("int")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("tbl_tag");
                });

            modelBuilder.Entity("Blog.Model.tbl_user", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(64) CHARACTER SET utf8mb4")
                        .HasMaxLength(64);

                    b.Property<string>("LastLoginAddr")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastLoginAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(64)")
                        .HasMaxLength(64);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime>("RegisterAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("tbl_user");
                });
#pragma warning restore 612, 618
        }
    }
}
