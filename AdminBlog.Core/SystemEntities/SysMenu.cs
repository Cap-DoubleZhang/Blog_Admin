using AdminBlog.Core.Enum;
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
    }
}
