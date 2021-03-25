using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 批量修改数据Dto 基类
    /// </summary>
    public class BaseBatchUpdateDto
    {
        /// <summary>
        /// 主键 集合
        /// </summary>
        public long[] ids { get; set; }
    }
}
