using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 系统菜单结果集Dto
    /// </summary>
    public class ResultSysMenuDto : BaseResultDto
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }

        /// <summary>
        /// 菜单Code
        /// </summary>
        public string menuCode { get; set; }

        /// <summary>
        /// 组件名称
        /// </summary>
        public string component { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string menuIcon { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string menuTitle { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string menuPath { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public UseTypeEnum isUse { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int sortIndex { get; set; }

        /// <summary>
        /// 路由 侧边栏是否显示
        /// </summary>
        public bool hidden { get; set; }

        /// <summary>
        /// 如果设置为true，它则会固定在tags-view中(默认 false)
        /// </summary>
        public bool affix { get; set; }

        /// <summary>
        /// 是否总是显示
        /// 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
        /// 只有一个时，会将那个子路由当做根路由显示在侧边栏--如引导页面
        /// 若你想不管路由下面的 children 声明的个数都显示你的根路由
        /// 你可以设置 alwaysShow: true，这样它就会忽略之前定义的规则，一直显示根路由
        /// </summary>
        public bool alwaysShow { get; set; }

        /// <summary>
        /// 是否缓存
        /// </summary>
        public bool noCache { get; set; }

        /// <summary>
        /// 当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
        /// </summary>
        public string redirect { get; set; }

        /// <summary>
        /// 菜单类型（按钮/页面）
        /// </summary>
        public MenuTypeEnum menuType { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        public long parentModuleID { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<ResultSysMenuDto> children { get; set; }
    }
}
