using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BlogType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Cover = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Synopsis = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReadingVolume = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PublishType = table.Column<int>(type: "int", nullable: false),
                    IsTop = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentHtml = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Keyword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FriendUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAllowedComments = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    ShowName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadPortrait = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Site = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Browser = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SystemVersion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IPHome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QQ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FriendlyLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendlyLinks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_Dictionary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCanMultiple = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Dictionary", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_Dictionary_Detail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetailCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Dictionary_Detail", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_EmailConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EmailType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SmtpUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPassword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_EmailConfig", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_File",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RealPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    MD5Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DownTimes = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_File", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MenuName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Component = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuIcon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentModuleID = table.Column<long>(type: "bigint", nullable: false),
                    MenuPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    Hidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Affix = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MenuSource = table.Column<int>(type: "int", nullable: false),
                    AlwaysShow = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Redirect = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoCache = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Menu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleDesc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminFlag = table.Column<int>(type: "int", nullable: false),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_RoleMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    MenuID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_RoleMenu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserLoginName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPassword = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripts = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOnline = table.Column<int>(type: "int", nullable: false),
                    LoginTimes = table.Column<int>(type: "int", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastLoginIP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_UserInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    UserShowName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadPortrait = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IDCard = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QQ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeChat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserInfo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserRole", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sys_WaterfallImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Src = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_WaterfallImages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Sys_Dictionary",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "IsCanMultiple", "IsDeleted", "Name", "Remark", "UpdateBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 160774000443461L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 149, DateTimeKind.Unspecified).AddTicks(1431), new TimeSpan(0, 0, 0, 0, 0)), false, false, "博客类型", null, null, null },
                    { 160776633155653L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 149, DateTimeKind.Unspecified).AddTicks(1434), new TimeSpan(0, 0, 0, 0, 0)), false, false, "邮箱类型", null, null, null },
                    { 169581276397637L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 149, DateTimeKind.Unspecified).AddTicks(1435), new TimeSpan(0, 0, 0, 0, 0)), true, false, "文章标签", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sys_Dictionary_Detail",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "DetailCode", "IsDeleted", "Remark", "SortIndex", "UpdateBy", "UpdatedTime", "Value" },
                values: new object[,]
                {
                    { 160774000443461L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1382), new TimeSpan(0, 0, 0, 0, 0)), "InformalEssay", false, null, 0, null, null, "随笔" },
                    { 160776633155653L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1385), new TimeSpan(0, 0, 0, 0, 0)), "Article", false, null, 1, null, null, "文章" },
                    { 161765323022405L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1386), new TimeSpan(0, 0, 0, 0, 0)), "TencentCompanyEmail", false, null, 0, null, null, "腾讯企业邮箱" },
                    { 161765323022406L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1387), new TimeSpan(0, 0, 0, 0, 0)), "163FreeEmail", false, null, 1, null, null, "163免费邮箱" },
                    { 161765323022407L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1388), new TimeSpan(0, 0, 0, 0, 0)), "Java", false, null, 0, null, null, "Java" },
                    { 161765323022408L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1390), new TimeSpan(0, 0, 0, 0, 0)), "C#", false, null, 1, null, null, "C#" },
                    { 161765323022409L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 0, 0, 0, 0)), "NET Core", false, null, 1, null, null, "NET Core" },
                    { 161765323022410L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 0, 0, 0, 0)), "JS", false, null, 1, null, null, "JS" },
                    { 161765323022411L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 150, DateTimeKind.Unspecified).AddTicks(1393), new TimeSpan(0, 0, 0, 0, 0)), "Vue", false, null, 1, null, null, "Vue" }
                });

            migrationBuilder.InsertData(
                table: "Sys_Menu",
                columns: new[] { "Id", "Affix", "AlwaysShow", "Component", "CreateBy", "CreatedTime", "Hidden", "IsDeleted", "IsUse", "MenuCode", "MenuIcon", "MenuName", "MenuPath", "MenuSource", "MenuTitle", "MenuType", "NoCache", "ParentModuleID", "Redirect", "SortIndex", "UpdateBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 183496627462213L, false, true, "layout", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1087), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "BlogManager", "el-icon-notebook-1", "博客管理目录", "/blog", 0, "博客管理", 0, false, 0L, null, 0, null, null },
                    { 183500800106565L, false, false, "blog", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1093), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "BlogList", "el-icon-notebook-1", "博客管理", "blog", 0, "博客管理", 0, false, 183496627462213L, null, 0, null, null },
                    { 184831157919813L, false, false, "layout", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "System", "el-icon-s-operation", "系统管理", "/system", 0, "系统管理", 0, false, 0L, null, 2, null, null },
                    { 184831279587397L, false, false, "user", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1096), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "UserList", "el-icon-s-custom", "用户管理", "users", 0, "用户管理", 0, false, 184831157919813L, null, 0, null, null },
                    { 184831426105413L, false, false, "role", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1097), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "RoleList", "el-icon-user", "角色管理", "roles", 0, "角色管理", 0, false, 184831157919813L, null, 1, null, null },
                    { 184831587602501L, false, false, "menu", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1099), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "MenusList", "el-icon-menu", "菜单管理", "menus", 0, "菜单管理", 0, false, 184831157919813L, null, 2, null, null },
                    { 184831951908933L, false, false, "dictionary", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "Dic", "el-icon-notebook-2", "字典管理", "dictionary", 0, "字典管理", 0, false, 184831157919813L, null, 3, null, null },
                    { 184832096215109L, false, false, "waterfallImages", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1102), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, "waterfallImages", "fa fa-image", "瀑布流图片", "waterfallImages", 0, "瀑布流图片", 0, false, 184831157919813L, null, 4, null, null },
                    { 188986113056837L, false, false, "createBlog", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, "createBlog", "", "创建", "createBlog", 0, "博客详情", 0, false, 183496627462213L, null, -2, null, null },
                    { 188992024399941L, false, false, "editBlog", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1105), new TimeSpan(0, 0, 0, 0, 0)), true, false, 0, "editBlog", "", "编辑", "editBlog/:id", 0, "博客详情", 0, false, 183496627462213L, null, -1, null, null },
                    { 189025873809477L, false, false, "uploadWaterfallImage", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "uploadWaterfallImage", "el-icon-picture", "上传图片", "uploadWaterfallImage", 0, "上传图片", 0, false, 184831157919813L, null, 5, null, null },
                    { 194092013764677L, false, true, "links", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1108), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "FriendlyLinks", "el-icon-link", "友链管理", "links", 0, "友链管理", 0, false, 194102723149893L, null, 1, null, null },
                    { 194102723149893L, false, false, "layout", null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 154, DateTimeKind.Unspecified).AddTicks(1107), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "LinksManager", "el-icon-link", "链接管理目录", "/link", 0, "链接管理", 0, false, 0L, null, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sys_Role",
                columns: new[] { "Id", "AdminFlag", "CreateBy", "CreatedTime", "IsDeleted", "IsUse", "RoleDesc", "RoleName", "UpdateBy", "UpdatedTime" },
                values: new object[] { 156951674213412L, 1, null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 162, DateTimeKind.Unspecified).AddTicks(79), new TimeSpan(0, 0, 0, 0, 0)), false, 0, null, "Admin", null, null });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "Descripts", "IsDeleted", "IsOnline", "IsUse", "LastLoginIP", "LastLoginTime", "LoginTimes", "UpdateBy", "UpdatedTime", "UserLoginName", "UserPassword" },
                values: new object[] { 156951674213412L, null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 164, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, 0, 0, 0, 0)), null, false, 0, 0, null, null, 0, null, null, "Admin", "728AD9902AECBA32E22F" });

            migrationBuilder.InsertData(
                table: "Sys_UserInfo",
                columns: new[] { "Id", "BirthDate", "CreateBy", "CreatedTime", "EMail", "HeadPortrait", "IDCard", "IsDeleted", "Phone", "QQ", "UpdateBy", "UpdatedTime", "UserID", "UserShowName", "WeChat" },
                values: new object[] { 111111L, null, null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 165, DateTimeKind.Unspecified).AddTicks(3027), new TimeSpan(0, 0, 0, 0, 0)), null, "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024", null, false, null, null, null, null, 156951674213412L, "Admin", null });

            migrationBuilder.InsertData(
                table: "Sys_UserRole",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "IsDeleted", "RoleID", "UpdateBy", "UpdatedTime", "UserID" },
                values: new object[] { 156951674213412L, null, new DateTimeOffset(new DateTime(2021, 12, 7, 13, 3, 24, 166, DateTimeKind.Unspecified).AddTicks(533), new TimeSpan(0, 0, 0, 0, 0)), false, 156951674213412L, null, null, 156951674213412L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "FriendlyLinks");

            migrationBuilder.DropTable(
                name: "Sys_Dictionary");

            migrationBuilder.DropTable(
                name: "Sys_Dictionary_Detail");

            migrationBuilder.DropTable(
                name: "Sys_EmailConfig");

            migrationBuilder.DropTable(
                name: "Sys_File");

            migrationBuilder.DropTable(
                name: "Sys_Menu");

            migrationBuilder.DropTable(
                name: "Sys_Role");

            migrationBuilder.DropTable(
                name: "Sys_RoleMenu");

            migrationBuilder.DropTable(
                name: "Sys_User");

            migrationBuilder.DropTable(
                name: "Sys_UserInfo");

            migrationBuilder.DropTable(
                name: "Sys_UserRole");

            migrationBuilder.DropTable(
                name: "Sys_WaterfallImages");
        }
    }
}
