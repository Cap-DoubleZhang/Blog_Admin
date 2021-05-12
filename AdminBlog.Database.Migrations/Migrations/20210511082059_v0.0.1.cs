using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingVolume = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    PublishType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    ShowName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadPortrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Dictionary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Dictionary_Detail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Dictionary_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_File",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    DownTimes = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentModuleID = table.Column<long>(type: "bigint", nullable: false),
                    MenuPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortIndex = table.Column<int>(type: "int", nullable: false),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminFlag = table.Column<int>(type: "int", nullable: false),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_RoleMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    MenuID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_RoleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserLoginName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripts = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsOnline = table.Column<int>(type: "int", nullable: false),
                    LoginTimes = table.Column<int>(type: "int", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUse = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    UserShowName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadPortrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeChat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "Descripts", "IsDeleted", "IsOnline", "IsUse", "LastLoginIP", "LastLoginTime", "LoginTimes", "UpdateBy", "UpdatedTime", "UserLoginName", "UserPassword" },
                values: new object[] { 15695167420013412L, null, new DateTimeOffset(new DateTime(2021, 5, 11, 8, 20, 58, 544, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 0, 0, 0, 0)), null, false, 0, 0, null, null, 0, null, null, "Admin", "728AD9902AECBA32E22F" });

            migrationBuilder.InsertData(
                table: "Sys_UserInfo",
                columns: new[] { "Id", "BirthDate", "CreateBy", "CreatedTime", "EMail", "HeadPortrait", "IDCard", "IsDeleted", "Phone", "QQ", "UpdateBy", "UpdatedTime", "UserID", "UserShowName", "WeChat" },
                values: new object[] { 111111L, null, null, new DateTimeOffset(new DateTime(2021, 5, 11, 8, 20, 58, 547, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 0, 0, 0, 0)), null, "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024", null, false, null, null, null, null, 15695167420013412L, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Sys_Dictionary");

            migrationBuilder.DropTable(
                name: "Sys_Dictionary_Detail");

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
        }
    }
}
