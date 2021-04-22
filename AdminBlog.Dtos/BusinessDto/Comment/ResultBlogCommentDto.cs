using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 博客下评论结果集 Dto
    /// </summary>
    public class ResultBlogCommentDto : BaseResultDto
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string value{ get; set; }
    }
}
