using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Component",
                table: "Sys_Menu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 185, DateTimeKind.Unspecified).AddTicks(8687), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 185, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 185, DateTimeKind.Unspecified).AddTicks(9337), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5831), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5969), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5971), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5973), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5974), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5986), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 190, DateTimeKind.Unspecified).AddTicks(5999), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 224, DateTimeKind.Unspecified).AddTicks(3741), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 8, 7, 3, 37, 44, 228, DateTimeKind.Unspecified).AddTicks(6514), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Component",
                table: "Sys_Menu");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 183, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 183, DateTimeKind.Unspecified).AddTicks(4274), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 183, DateTimeKind.Unspecified).AddTicks(4278), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8435), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8478), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8480), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8482), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8488), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8490), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8491), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 186, DateTimeKind.Unspecified).AddTicks(8493), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 203, DateTimeKind.Unspecified).AddTicks(8248), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 7, 27, 15, 0, 25, 205, DateTimeKind.Unspecified).AddTicks(8618), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
