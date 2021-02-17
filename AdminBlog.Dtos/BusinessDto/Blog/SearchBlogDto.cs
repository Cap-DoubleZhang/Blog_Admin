using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索博客列表Dto
    /// </summary>
    public class SearchBlogDto : BaseSearchDto
    {
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool? IsPublish { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishBeginTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishEndTime { get; set; }
    }
}
