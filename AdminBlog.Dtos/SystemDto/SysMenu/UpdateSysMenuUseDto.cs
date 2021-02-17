using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    public class UpdateSysMenuUseDto : BaseBatchUpdateDto
    {
        /// <summary>
        /// 禁用类型
        /// </summary>
        public UseTypeEnum IsUse { get; set; }
    }
}
