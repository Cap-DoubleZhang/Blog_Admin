using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidFlag",
                table: "Sys_UserRole");

            migrationBuilder.DropColumn(
                name: "ValigFlag",
                table: "Sys_User");

            migrationBuilder.DropColumn(
                name: "ValidFlag",
                table: "Sys_RoleMenu");

            migrationBuilder.RenameColumn(
                name: "UserPassworrd",
                table: "Sys_User",
                newName: "UserPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Sys_User",
                newName: "UserPassworrd");

            migrationBuilder.AddColumn<int>(
                name: "ValidFlag",
                table: "Sys_UserRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValigFlag",
                table: "Sys_User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValidFlag",
                table: "Sys_RoleMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
