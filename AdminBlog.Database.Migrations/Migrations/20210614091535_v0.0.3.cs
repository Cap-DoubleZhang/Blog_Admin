using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanMultiple",
                table: "Sys_Dictionary",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 40, DateTimeKind.Unspecified).AddTicks(4268), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 40, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Sys_Dictionary",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "IsCanMultiple", "IsDeleted", "Name", "Remark", "UpdateBy", "UpdatedTime" },
                values: new object[] { 169581276397637L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 40, DateTimeKind.Unspecified).AddTicks(4761), new TimeSpan(0, 0, 0, 0, 0)), false, false, "文章标签", null, null, null });

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4911), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4946), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4948), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4950), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Sys_Dictionary_Detail",
                columns: new[] { "Id", "Code", "CreateBy", "CreatedTime", "DetailCode", "IsDeleted", "Remark", "SortIndex", "UpdateBy", "UpdatedTime", "Value" },
                values: new object[,]
                {
                    { 161765323022407L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4951), new TimeSpan(0, 0, 0, 0, 0)), "Java", false, null, 0, null, null, "Java" },
                    { 161765323022408L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4956), new TimeSpan(0, 0, 0, 0, 0)), "C#", false, null, 1, null, null, "C#" },
                    { 161765323022409L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 0, 0, 0, 0)), "NET Core", false, null, 1, null, null, "NET Core" },
                    { 161765323022410L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4959), new TimeSpan(0, 0, 0, 0, 0)), "JS", false, null, 1, null, null, "JS" },
                    { 161765323022411L, "BlogLabel", null, new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 43, DateTimeKind.Unspecified).AddTicks(4961), new TimeSpan(0, 0, 0, 0, 0)), "Vue", false, null, 1, null, null, "Vue" }
                });

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 61, DateTimeKind.Unspecified).AddTicks(559), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                columns: new[] { "CreatedTime", "UserID" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 6, 14, 9, 15, 35, 63, DateTimeKind.Unspecified).AddTicks(4658), new TimeSpan(0, 0, 0, 0, 0)), 156951674213412L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L);

            migrationBuilder.DeleteData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L);

            migrationBuilder.DropColumn(
                name: "IsCanMultiple",
                table: "Sys_Dictionary");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 822, DateTimeKind.Unspecified).AddTicks(3633), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 822, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(933), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(970), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 825, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 840, DateTimeKind.Unspecified).AddTicks(7840), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                columns: new[] { "CreatedTime", "UserID" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 5, 25, 14, 49, 5, 842, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 0, 0, 0, 0)), 15695167420013412L });
        }
    }
}
