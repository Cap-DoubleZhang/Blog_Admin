using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 文件详情错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum FileEnum
    {
        /// <summary>
        /// 该文件不存在或已被删除
        /// </summary>
        [ErrorCodeItemMetadata("该文件不存在或已被删除.")]
        FileNonExist,

        /// <summary>
        /// 请选择要上传完的文件
        /// </summary>
        [ErrorCodeItemMetadata("请选择要上传完的文件.")]
        InputFileNonExist,
    }
}
