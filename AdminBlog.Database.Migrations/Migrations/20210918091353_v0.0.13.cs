using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminBlog.Database.Migrations.Migrations
{
    public partial class v0013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 65, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 65, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 65, DateTimeKind.Unspecified).AddTicks(8893), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7849), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7890), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7892), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7894), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7897), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 68, DateTimeKind.Unspecified).AddTicks(7902), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Sys_Menu",
                columns: new[] { "Id", "Affix", "AlwaysShow", "Component", "CreateBy", "CreatedTime", "Hidden", "IsDeleted", "IsUse", "MenuCode", "MenuIcon", "MenuName", "MenuPath", "MenuSource", "MenuTitle", "MenuType", "NoCache", "ParentModuleID", "Redirect", "SortIndex", "UpdateBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 183496627462213L, false, true, "layout", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5363), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "BlogManager", "el-icon-notebook-1", "博客管理目录", "/blog", 0, "博客管理", 0, false, 0L, null, 0, null, null },
                    { 194092013764677L, false, true, "links", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5781), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "FriendlyLinks", "el-icon-link", "友链管理", "links", 0, "友链管理", 0, false, 194102723149893L, null, 1, null, null },
                    { 194102723149893L, false, false, "layout", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5780), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "LinksManager", "el-icon-link", "链接管理目录", "/link", 0, "链接管理", 0, false, 0L, null, 1, null, null },
                    { 189025873809477L, false, false, "uploadWaterfallImage", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5778), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "uploadWaterfallImage", "el-icon-picture", "上传图片", "uploadWaterfallImage", 0, "上传图片", 0, false, 184831157919813L, null, 5, null, null },
                    { 189020521594949L, false, false, "userinfo", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5776), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "userinfo", "el-icon-s-custom", "用户信息", "userinfo", 0, "用户信息", 0, false, 184831157919813L, null, 0, null, null },
                    { 188992024399941L, false, false, "editBlog", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5774), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "editBlog", "", "编辑", "editBlog/:id(\\d+)", 0, "博客详情", 0, false, 184831157919813L, null, -1, null, null },
                    { 188986113056837L, false, false, "createBlog", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "createBlog", "", "创建", "createBlog", 0, "博客详情", 0, false, 184831157919813L, null, -2, null, null },
                    { 184832096215109L, false, false, "waterfallImages", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5769), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "waterfallImages", "fa fa-image", "瀑布流图片", "waterfallImages", 0, "瀑布流图片", 0, false, 184831157919813L, null, 4, null, null },
                    { 184831951908933L, false, false, "dictionary", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "Dic", "el-icon-notebook-2", "字典管理", "dictionary", 0, "字典管理", 0, false, 184831157919813L, null, 3, null, null },
                    { 184831587602501L, false, false, "menu", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5730), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "MenusList", "el-icon-menu", "菜单管理", "menus", 0, "菜单管理", 0, false, 184831157919813L, null, 2, null, null },
                    { 184831426105413L, false, false, "role", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "RoleList", "el-icon-user", "角色管理", "roles", 0, "角色管理", 0, false, 184831157919813L, null, 1, null, null },
                    { 184831279587397L, false, false, "user", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5718), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "UserList", "el-icon-s-custom", "用户管理", "users", 0, "用户管理", 0, false, 184831157919813L, null, 0, null, null },
                    { 184831157919813L, false, false, "layout", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5712), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "System", "el-icon-s-operation", "系统管理", "/system", 0, "系统管理", 0, false, 0L, null, 2, null, null },
                    { 183500800106565L, false, false, "blog", null, new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 80, DateTimeKind.Unspecified).AddTicks(5414), new TimeSpan(0, 0, 0, 0, 0)), false, false, 0, "BlogList", "el-icon-notebook-1", "博客管理", "blog", 0, "博客管理", 0, false, 183496627462213L, null, 0, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 87, DateTimeKind.Unspecified).AddTicks(7257), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 13, 53, 90, DateTimeKind.Unspecified).AddTicks(2369), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183496627462213L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 183500800106565L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831157919813L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831279587397L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831426105413L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831587602501L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184831951908933L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 184832096215109L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188986113056837L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 188992024399941L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189020521594949L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 189025873809477L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194092013764677L);

            migrationBuilder.DeleteData(
                table: "Sys_Menu",
                keyColumn: "Id",
                keyValue: 194102723149893L);

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 52, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 52, DateTimeKind.Unspecified).AddTicks(7423), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary",
                keyColumn: "Id",
                keyValue: 169581276397637L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 52, DateTimeKind.Unspecified).AddTicks(7428), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160774000443461L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7264), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 160776633155653L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7305), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022405L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022406L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7309), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022407L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7310), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022408L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7314), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022409L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7315), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022410L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7317), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_Dictionary_Detail",
                keyColumn: "Id",
                keyValue: 161765323022411L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 55, DateTimeKind.Unspecified).AddTicks(7319), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_User",
                keyColumn: "Id",
                keyValue: 156951674213412L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 75, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Sys_UserInfo",
                keyColumn: "Id",
                keyValue: 111111L,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2021, 9, 18, 9, 11, 21, 78, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
