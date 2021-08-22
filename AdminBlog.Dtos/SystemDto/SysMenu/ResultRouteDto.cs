using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 对应前端路由表 Dto
    /// </summary>
    public class ResultRouteDto
    {
        /// <summary>
        /// URL显示路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// views路径
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool hidden { get; set; }
        /// <summary>
        /// 是否总是显示
        /// 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
        /// 只有一个时，会将那个子路由当做根路由显示在侧边栏--如引导页面
        /// 若你想不管路由下面的 children 声明的个数都显示你的根路由
        /// 你可以设置 alwaysShow: true，这样它就会忽略之前定义的规则，一直显示根路由
        /// </summary>
        public bool alwaysShow { get; set; }
        /// <summary>
        /// 子路由菜单显示内容
        /// </summary>
        public Meta meta { get; set; }
        ///// <summary>
        ///// 当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
        ///// </summary>
        //public string redirect { get; set; }
        /// <summary>
        /// 设定路由的名字，一定要填写不然使用<keep-alive>时会出现各种问题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 子路由
        /// </summary>
        public List<ResultRouteDto> children { get; set; }
    }

    /// <summary>
    /// 对应路由表中 meta
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 显示在左侧路由的标题名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 可以查看该路由的角色
        /// </summary>
        public string[] roles { get; set; }

        /// <summary>
        /// 是否可缓存
        /// </summary>
        public bool noCache { get; set; }
    }
}
