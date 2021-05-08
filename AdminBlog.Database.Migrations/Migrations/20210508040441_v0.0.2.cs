using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "Descripts", "IsDeleted", "IsOnline", "IsUse", "LastLoginIP", "LastLoginTime", "LoginTimes", "UpdateBy", "UpdatedTime", "UserLoginName", "UserPassword" },
                values: new object[] { 1111L, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, 0, 0, null, null, 0, null, null, "Admin", "广东省中山市" });

            migrationBuilder.InsertData(
                table: "Sys_UserInfo",
                columns: new[] { "Id", "BirthDate", "CreateBy", "CreatedTime", "EMail", "HeadPortrait", "IDCard", "IsDeleted", "Phone", "QQ", "UpdateBy", "UpdatedTime", "UserID", "UserShowName", "WeChat" },
                values: new object[] { 111111L, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024", null, false, null, null, null, null, 1111L, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 1111L);

            migrationBuilder.DeleteData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L);
        }
    }
}
