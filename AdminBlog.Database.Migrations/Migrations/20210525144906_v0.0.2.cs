using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 15695167420013412L);

            migrationBuilder.CreateTable(
                name: "Sys_EmailConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EmailType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdateBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_EmailConfig", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sys_Dictionary",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "IsDeleted", "Name", "Remark", "UpdateBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 160774000443461L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 822, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 0, 0, 0, 0)), false, "博客类型", null, null, null },
                    { 160776633155653L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 822, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 0, 0, 0, 0)), false, "邮箱类型", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sys_Dictionary_Detail",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "DetailCode", "IsDeleted", "Remark", "SortIndex", "UpdateBy", "UpdatedTime", "Value" },
                values: new object[,]
                {
                    { 160774000443461L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 0, 0, 0, 0)), "InformalEssay", false, null, 0, null, null, "随笔" },
                    { 160776633155653L, "BlogType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 0, 0, 0, 0)), "Article", false, null, 1, null, null, "文章" },
                    { 161765323022405L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 0, 0, 0, 0)), "TencentCompanyEmail", false, null, 0, null, null, "腾讯企业邮箱" },
                    { 161765323022406L, "EmailType", null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 0, 0, 0, 0)), "163FreeEmail", false, null, 1, null, null, "163免费邮箱" }
                });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "Descripts", "IsDeleted", "IsOnline", "IsUse", "LastLoginIP", "LastLoginTime", "LoginTimes", "UpdateBy", "UpdatedTime", "UserLoginName", "UserPassword" },
                values: new object[] { 156951674213412L, null, new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 840, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 0, 0, 0, 0)), null, false, 0, 0, null, null, 0, null, null, "Admin", "728AD9902AECBA32E22F" });

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 842, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_EmailConfig");

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L);

            migrationBuilder.DeleteData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L);

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "CreateBy", "CreatedTime", "Descripts", "IsDeleted", "IsOnline", "IsUse", "LastLoginIP", "LastLoginTime", "LoginTimes", "UpdateBy", "UpdatedTime", "UserLoginName", "UserPassword" },
                values: new object[] { 15695167420013412L, null, new DateTimeOffset(new DateTime(2021, 5, 11, 8, 20, 58, 544, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 0, 0, 0, 0)), null, false, 0, 0, null, null, 0, null, null, "Admin", "728AD9902AECBA32E22F" });

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 11, 8, 20, 58, 547, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
