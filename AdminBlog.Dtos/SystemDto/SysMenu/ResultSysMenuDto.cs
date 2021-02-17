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
        /// 菜单类型（按钮/页面）
        /// </summary>
        public MenuTypeEnum menuType { get; set; }
        public List<ResultSysMenuDto> childrenMens { get; set; }
    }
}
