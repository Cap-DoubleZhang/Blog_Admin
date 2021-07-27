using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Affix",
                table: "Sys_Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Sys_Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuSource",
                table: "Sys_Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Affix",
                table: "Sys_Menu");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Sys_Menu");

            migrationBuilder.DropColumn(
                name: "MenuSource",
                table: "Sys_Menu");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(4547), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 682, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(3979), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4012), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4015), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4018), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4064), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4066), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 685, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 701, DateTimeKind.Unspecified).AddTicks(4334), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 6, 19, 7, 27, 47, 703, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
