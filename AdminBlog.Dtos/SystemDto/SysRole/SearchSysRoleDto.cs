using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    public class SearchSysRoleDto : BaseSearchDto
    {
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public int adminFlag { get; set; } = -1;
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int isUse { get; set; } = -1;
    }
}
