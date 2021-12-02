using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v0017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MD5Value",
                table: "Sys_File",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 511, DateTimeKind.Unspecified).AddTicks(5846), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 511, DateTimeKind.Unspecified).AddTicks(5849), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 511, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5273), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5276), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5277), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5278), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5279), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5282), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5283), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 512, DateTimeKind.Unspecified).AddTicks(5285), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183496627462213L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2434), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183500800106565L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831157919813L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831279587397L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2440), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831426105413L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2441), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831587602501L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2443), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831951908933L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2445), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184832096215109L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2446), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188986113056837L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2447), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188992024399941L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189025873809477L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2451), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194092013764677L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194102723149893L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 524, DateTimeKind.Unspecified).AddTicks(2452), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Role",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 525, DateTimeKind.Unspecified).AddTicks(1319), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 526, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 528, DateTimeKind.Unspecified).AddTicks(648), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserRole",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 2, 15, 2, 15, 528, DateTimeKind.Unspecified).AddTicks(7564), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MD5Value",
                table: "Sys_File");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 836, DateTimeKind.Unspecified).AddTicks(5828), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 836, DateTimeKind.Unspecified).AddTicks(6269), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 836, DateTimeKind.Unspecified).AddTicks(6624), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(515), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(573), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(577), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(578), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 840, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183496627462213L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(477), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183500800106565L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(539), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831157919813L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831279587397L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(968), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831426105413L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(971), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831587602501L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(977), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831951908933L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(981), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184832096215109L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1377), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188986113056837L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1385), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188992024399941L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189025873809477L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1392), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194092013764677L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1397), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194102723149893L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 853, DateTimeKind.Unspecified).AddTicks(1394), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Role",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 857, DateTimeKind.Unspecified).AddTicks(1085), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 864, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 866, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserRole",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 27, 6, 46, 4, 868, DateTimeKind.Unspecified).AddTicks(1238), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
