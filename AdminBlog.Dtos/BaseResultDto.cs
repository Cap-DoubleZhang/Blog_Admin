using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 结果集/结果Dto 基类
    /// </summary>
    public class BaseResultDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset CreatedTime { get; set; }
    }
}
