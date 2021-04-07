using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 查询菜单列表 Dto
    /// </summary>
    public class SearchSysMenuDto : BaseSearchDto
    {
        /// <summary>
        /// 父级菜单 ids
        /// </summary>
        public long[] menuIds { get; set; }
        /// <summary>
        /// 管理员状态
        /// </summary>
        public int adminFlag { get; set; } = -1;
        /// <summary>
        /// 是否可用
        /// </summary>
        public int isUse { get; set; } = -1;
    }
}
