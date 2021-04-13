﻿// <auto-generated />
using System;
using AdminBlog.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminBlog.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("AdminBlog.Core.Blog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BlogType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("PublishTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PublishType")
                        .HasColumnType("int");

                    b.Property<int>("ReadingVolume")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("AdminBlog.Core.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Browser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadPortrait")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPHome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("QQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShowName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Value")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("AdminBlog.Core.SysDictionary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_Dictionary");
                });

            modelBuilder.Entity("AdminBlog.Core.SysDictionaryDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DetailCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortIndex")
                        .HasColumnType("int");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sys_Dictionary_Detail");
                });

            modelBuilder.Entity("AdminBlog.Core.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("IsUse")
                        .HasColumnType("int")
                        .HasColumnName("IsUse");

                    b.Property<string>("MenuCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MenuCode");

                    b.Property<string>("MenuIcon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MenuIcon");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MenuName");

                    b.Property<string>("MenuPath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MenuPath");

                    b.Property<string>("MenuTitle")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MenuTitle");

                    b.Property<int>("MenuType")
                        .HasColumnType("int")
                        .HasColumnName("MenuType");

                    b.Property<long>("ParentModuleID")
                        .HasColumnType("bigint")
                        .HasColumnName("ParentModuleID");

                    b.Property<int>("SortIndex")
                        .HasColumnType("int")
                        .HasColumnName("SortIndex");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_Menu");
                });

            modelBuilder.Entity("AdminBlog.Core.SysRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("AdminFlag")
                        .HasColumnType("int")
                        .HasColumnName("AdminFlag");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("IsUse")
                        .HasColumnType("int")
                        .HasColumnName("IsUse");

                    b.Property<string>("RoleDesc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoleDesc");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoleName");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_Role");
                });

            modelBuilder.Entity("AdminBlog.Core.SysRoleMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("MenuID")
                        .HasColumnType("bigint")
                        .HasColumnName("MenuID");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint")
                        .HasColumnName("RoleID");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_RoleMenu");
                });

            modelBuilder.Entity("AdminBlog.Core.SysUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descripts")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Descripts");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("IsOnline")
                        .HasColumnType("int")
                        .HasColumnName("IsOnline");

                    b.Property<int>("IsUse")
                        .HasColumnType("int")
                        .HasColumnName("IsUse");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastLoginIP");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastLoginTime");

                    b.Property<int>("LoginTimes")
                        .HasColumnType("int")
                        .HasColumnName("LoginTimes");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserLoginName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("UserLoginName");

                    b.Property<string>("UserPassword")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UserPassword");

                    b.HasKey("Id");

                    b.ToTable("Sys_User");
                });

            modelBuilder.Entity("AdminBlog.Core.SysUserInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMail");

                    b.Property<string>("HeadPortrait")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadPortrait");

                    b.Property<string>("IDCard")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IDCard");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone");

                    b.Property<string>("QQ")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("QQ");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint")
                        .HasColumnName("UserID");

                    b.Property<string>("UserShowName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserShowName");

                    b.Property<string>("WeChat")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WeChat");

                    b.HasKey("Id");

                    b.ToTable("Sys_UserInfo");
                });

            modelBuilder.Entity("AdminBlog.Core.SysUserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint")
                        .HasColumnName("RoleID");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.ToTable("Sys_UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
