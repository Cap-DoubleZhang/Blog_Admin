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
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdminBlog.Core.Blog", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

                    b.Property<long>("BlogId")
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsCanMultiple")
                        .HasColumnType("bit");

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

                    b.HasData(
                        new
                        {
                            Id = 160774000443461L,
                            Code = "BlogType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 0, 0, 0, 0)),
                            IsCanMultiple = false,
                            IsDeleted = false,
                            Name = "博客类型"
                        },
                        new
                        {
                            Id = 160776633155653L,
                            Code = "EmailType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 0, 0, 0, 0)),
                            IsCanMultiple = false,
                            IsDeleted = false,
                            Name = "邮箱类型"
                        },
                        new
                        {
                            Id = 169581276397637L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 0, 0, 0, 0)),
                            IsCanMultiple = false,
                            IsDeleted = false,
                            Name = "文章标签"
                        });
                });

            modelBuilder.Entity("AdminBlog.Core.SysDictionaryDetail", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

                    b.HasData(
                        new
                        {
                            Id = 160774000443461L,
                            Code = "BlogType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "InformalEssay",
                            IsDeleted = false,
                            SortIndex = 0,
                            Value = "随笔"
                        },
                        new
                        {
                            Id = 160776633155653L,
                            Code = "BlogType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "Article",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "文章"
                        },
                        new
                        {
                            Id = 161765323022405L,
                            Code = "EmailType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "TencentCompanyEmail",
                            IsDeleted = false,
                            SortIndex = 0,
                            Value = "腾讯企业邮箱"
                        },
                        new
                        {
                            Id = 161765323022406L,
                            Code = "EmailType",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "163FreeEmail",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "163免费邮箱"
                        },
                        new
                        {
                            Id = 161765323022407L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4018), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "Java",
                            IsDeleted = false,
                            SortIndex = 0,
                            Value = "Java"
                        },
                        new
                        {
                            Id = 161765323022408L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "C#",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "C#"
                        },
                        new
                        {
                            Id = 161765323022409L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "NET Core",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "NET Core"
                        },
                        new
                        {
                            Id = 161765323022410L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4066), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "JS",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "JS"
                        },
                        new
                        {
                            Id = 161765323022411L,
                            Code = "BlogLabel",
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 0, 0, 0, 0)),
                            DetailCode = "Vue",
                            IsDeleted = false,
                            SortIndex = 1,
                            Value = "Vue"
                        });
                });

            modelBuilder.Entity("AdminBlog.Core.SysEmailConfig", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EmailPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SmtpUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Sys_EmailConfig");
                });

            modelBuilder.Entity("AdminBlog.Core.SysFile", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DownTimes")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RealPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_File");
                });

            modelBuilder.Entity("AdminBlog.Core.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

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

                    b.HasData(
                        new
                        {
                            Id = 156951674213412L,
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 701, DateTimeKind.Unspecified).AddTicks(4334), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsOnline = 0,
                            IsUse = 0,
                            LoginTimes = 0,
                            UserLoginName = "Admin",
                            UserPassword = "728AD9902AECBA32E22F"
                        });
                });

            modelBuilder.Entity("AdminBlog.Core.SysUserInfo", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

                    b.HasData(
                        new
                        {
                            Id = 111111L,
                            CreatedTime = new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 703, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)),
                            HeadPortrait = "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024",
                            IsDeleted = false,
                            UserID = 156951674213412L,
                            UserShowName = "Admin"
                        });
                });

            modelBuilder.Entity("AdminBlog.Core.SysUserRole", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("AdminBlog.Core.SysWaterfallImages", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Sys_WaterfallImages");
                });
#pragma warning restore 612, 618
        }
    }
}
