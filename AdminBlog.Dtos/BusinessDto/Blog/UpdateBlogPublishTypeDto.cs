using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 更改博客的类型 Dto
    /// </summary>
    public class UpdateBlogPublishTypeDto : BaseBatchUpdateDto
    {
        /// <summary>
        /// 发布类型
        /// </summary>
        public BlogPublishTypeEnum publishType { get; set; }
    }
}
