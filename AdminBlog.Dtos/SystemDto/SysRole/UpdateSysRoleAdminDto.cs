using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    public class UpdateSysRoleAdminDto : BaseBatchUpdateDto
    {
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public AdminTypeEnum adminFlag { get; set; }
    }
}
