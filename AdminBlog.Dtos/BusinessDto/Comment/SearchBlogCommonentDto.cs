using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索博客下评论 Dto
    /// </summary>
    public class SearchBlogCommonentDto : BaseSearchDto
    {
        /// <summary>
        /// 所属博客ID
        /// </summary>
        public long blogId { get; set; }
    }
}
