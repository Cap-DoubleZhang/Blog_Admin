using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 更改系统角色可用Dto
    /// </summary>
    public class UpdateSysRoleUseDto : BaseBatchUpdateDto
    {
        /// <summary>
        /// 禁用类型
        /// </summary>
        public UseTypeEnum IsUse { get; set; }
    }
}
