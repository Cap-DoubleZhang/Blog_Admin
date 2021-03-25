using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 评论错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum CommentErrorCodeEnum
    {
        /// <summary>
        /// 该博客不存在,无法评论
        /// </summary>
        [ErrorCodeItemMetadata("该博客不存在,无法评论.")]
        CommentBlogNonExist,
    }
}
