using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 博客错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum BlogErrorCodeEnum
    {
        [ErrorCodeItemMetadata("该数据不存在或已被删除.")]
        NonExist,
    }
}
