using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索Dto 基类
    /// </summary>
    public class BaseSearchDto
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageIndex { get; set; } = 1;
        /// <summary>
        /// 页容量
        /// </summary>
        public int pageSize { get; set; } = 10;
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string keyword { get; set; } = "";
    }
}
