using AdminBlog.Core.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 后台菜单表
    /// </summary>
    [Table("Sys_Menu")]
    [Description("后台菜单表")]
    public class SysMenu : EntityExtend
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("MenuName")]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单Code
        /// </summary>
        [Column("MenuCode")]
        public string MenuCode { get; set; }
        /// <summary>
        /// 组件名称
        /// </summary>
        [Column("Component")]
        public string Component { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Column("MenuIcon")]
        public string MenuIcon { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        [Column("MenuTitle")]
        public string MenuTitle { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        [Column("ParentModuleID")]
        public long ParentModuleID { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        [Column("MenuPath")]
        public string MenuPath { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Column("SortIndex")]
        public int SortIndex { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Column("IsUse")]
        public UseTypeEnum IsUse { get; set; }

        /// <summary>
        /// 菜单类型（按钮/页面）
        /// </summary>
        [Column("MenuType")]
        public MenuTypeEnum MenuType { get; set; }

        /// <summary>
        /// 路由 侧边栏是否显示
        /// </summary>
        [Column("Hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// 如果设置为true，它则会固定在tags-view中(默认 false)
        /// </summary>
        [Column("Affix")]
        public bool Affix { get; set; }

        /// <summary>
        /// 菜单来源（前台菜单、后台菜单）
        /// </summary>
        [Column("MenuSource")]
        public MenuSourceEnum MenuSource { get; set; }

        /// <summary>
        /// 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
        /// 只有一个时，会将那个子路由当做根路由显示在侧边栏--如引导页面
        /// 若你想不管路由下面的 children 声明的个数都显示你的根路由
        /// 你可以设置 alwaysShow: true，这样它就会忽略之前定义的规则，一直显示根路由
        /// </summary>
        [Column("AlwaysShow")]
        public bool AlwaysShow { get; set; }

        /// <summary>
        /// 重定向地址，在面包屑中点击会重定向去的地址
        /// 当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
        /// </summary>
        [Column("Redirect")]
        public string Redirect { get; set; }

        /// <summary>
        /// true：不会被 keep-alive 缓存
        /// </summary>
        [Column("NoCache")]
        public bool NoCache { get; set; }

        /// <summary>
        /// 增加种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysMenu> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<SysMenu>
            {
                new SysMenu { Id = 183496627462213, MenuName = "博客管理目录", MenuCode = "BlogManager",MenuIcon="el-icon-notebook-1",MenuTitle="博客管理",ParentModuleID=0,MenuPath="/blog",Component="layout",AlwaysShow=true,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 183500800106565, MenuName = "博客管理", MenuCode = "BlogList",MenuIcon="el-icon-notebook-1",MenuTitle="博客管理",ParentModuleID=183496627462213,MenuPath="blog",Component="blog",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184831157919813, MenuName = "系统管理", MenuCode = "System",MenuIcon="el-icon-s-operation",MenuTitle="系统管理",ParentModuleID=0,MenuPath="/system",SortIndex=2,Component="layout",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184831279587397, MenuName = "用户管理", MenuCode = "UserList",MenuIcon="el-icon-s-custom",MenuTitle="用户管理",ParentModuleID=184831157919813,MenuPath="users",SortIndex=0,Component="user",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184831426105413, MenuName = "角色管理", MenuCode = "RoleList",MenuIcon="el-icon-user",MenuTitle="角色管理",ParentModuleID=184831157919813,MenuPath="roles",SortIndex=1,Component="role",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184831587602501, MenuName = "菜单管理", MenuCode = "MenusList",MenuIcon="el-icon-menu",MenuTitle="菜单管理",ParentModuleID=184831157919813,MenuPath="menus",SortIndex=2,Component="menu",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184831951908933, MenuName = "字典管理", MenuCode = "Dic",MenuIcon="el-icon-notebook-2",MenuTitle="字典管理",ParentModuleID=184831157919813,MenuPath="dictionary",SortIndex=3,Component="dictionary",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 184832096215109, MenuName = "瀑布流图片", MenuCode = "waterfallImages",MenuIcon="fa fa-image",MenuTitle="瀑布流图片",ParentModuleID=184831157919813,MenuPath="waterfallImages",SortIndex=4,Component="waterfallImages",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 188986113056837, MenuName = "创建", MenuCode = "createBlog",MenuIcon="",MenuTitle="博客详情",ParentModuleID=184831157919813,MenuPath="createBlog",SortIndex=-2,Component="createBlog",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 188992024399941, MenuName = "编辑", MenuCode = "editBlog",MenuIcon="",MenuTitle="博客详情",ParentModuleID=184831157919813,MenuPath="editBlog/:id(\\d+)",SortIndex=-1,Component="editBlog",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 189020521594949, MenuName = "用户信息", MenuCode = "userinfo",MenuIcon="el-icon-s-custom",MenuTitle="用户信息",ParentModuleID=184831157919813,MenuPath="userinfo",SortIndex=0,Component="userinfo",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 189025873809477, MenuName = "上传图片", MenuCode = "uploadWaterfallImage",MenuIcon="el-icon-picture",MenuTitle="上传图片",ParentModuleID=184831157919813,MenuPath="uploadWaterfallImage",SortIndex=5,Component="uploadWaterfallImage",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 194102723149893, MenuName = "链接管理目录", MenuCode = "LinksManager",MenuIcon="el-icon-link",MenuTitle="链接管理",ParentModuleID=0,MenuPath="/link",SortIndex=1,Component="layout",AlwaysShow=false,CreatedTime=DateTimeOffset.UtcNow },
                new SysMenu { Id = 194092013764677, MenuName = "友链管理", MenuCode = "FriendlyLinks",MenuIcon="el-icon-link",MenuTitle="友链管理",ParentModuleID=194102723149893,MenuPath="links",SortIndex=1,Component="links",AlwaysShow=true,CreatedTime=DateTimeOffset.UtcNow },
            };
        }
    }
}
