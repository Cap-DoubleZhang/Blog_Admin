using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 查询评论Dto
    /// </summary>
    public class SearchCommentDto : BaseSearchDto
    {
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? beginTime { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? endTime { get; set; }
    }
}
