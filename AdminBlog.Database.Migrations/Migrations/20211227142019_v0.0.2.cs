using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Sys_File",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 688, DateTimeKind.Unspecified).AddTicks(3291), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 688, DateTimeKind.Unspecified).AddTicks(3295), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 688, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4622), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4626), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4627), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4628), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4629), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4631), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4632), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4633), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 689, DateTimeKind.Unspecified).AddTicks(4634), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183496627462213L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3855), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183500800106565L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3861), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831157919813L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3864), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831279587397L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3865), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831426105413L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3866), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831587602501L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3870), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831951908933L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3872), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184832096215109L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3874), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188986113056837L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3876), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188992024399941L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3880), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189025873809477L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3882), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194092013764677L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3886), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194102723149893L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 706, DateTimeKind.Unspecified).AddTicks(3884), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Role",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 708, DateTimeKind.Unspecified).AddTicks(1708), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 711, DateTimeKind.Unspecified).AddTicks(7842), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 714, DateTimeKind.Unspecified).AddTicks(3098), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserRole",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 27, 14, 20, 18, 716, DateTimeKind.Unspecified).AddTicks(546), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Site",
                table: "Sys_File");

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 353, DateTimeKind.Unspecified).AddTicks(9329), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 353, DateTimeKind.Unspecified).AddTicks(9331), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 353, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8825), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8828), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8829), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8831), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8833), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8835), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 354, DateTimeKind.Unspecified).AddTicks(8836), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183496627462213L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2470), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183500800106565L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831157919813L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2480), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831279587397L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2481), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831426105413L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831587602501L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2487), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831951908933L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2488), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184832096215109L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188986113056837L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2491), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188992024399941L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2494), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189025873809477L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2496), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194092013764677L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2499), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194102723149893L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 359, DateTimeKind.Unspecified).AddTicks(2497), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Role",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 360, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 363, DateTimeKind.Unspecified).AddTicks(3647), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 364, DateTimeKind.Unspecified).AddTicks(6535), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserRole",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 12, 23, 15, 38, 24, 365, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
