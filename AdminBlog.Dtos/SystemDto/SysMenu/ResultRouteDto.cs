using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos.SystemDto.SysMenu
{
    /// <summary>
    /// 对应前端路由表 Dto
    /// </summary>
    public class ResultRouteDto
    {
        public string path { get; set; }
        public string component { get; set; }
        public bool hidden { get; set; }
        public string redirect { get; set; }
        public bool alwaysShow { get; set; }
        public Meta meta { get; set; }
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
    }
}
