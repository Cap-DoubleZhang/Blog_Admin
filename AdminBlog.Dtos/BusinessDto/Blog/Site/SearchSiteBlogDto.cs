using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 查询博客详情 Dto
    /// </summary>
    public class SearchSiteBlogDto
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int month { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public int day { get; set; }
        /// <summary>
        /// 主键ID / 友好地址
        /// </summary>
        public string id { get; set; }
    }
}
