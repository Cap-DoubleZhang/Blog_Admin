using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 系统字典详情错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum DictionaryDetailErrorCodeEnum
    {
        /// <summary>
        /// 该字典数据明细不存在或已被删除
        /// </summary>
        [ErrorCodeItemMetadata("该字典数据明细不存在或已被删除.")]
        DictionaryDetailNonExist,

        /// <summary>
        /// 该字典明细值编码已存在
        /// </summary>
        [ErrorCodeItemMetadata("该字典明细值编码已存在.")]
        DictionaryDetailCodeExist,

        /// <summary>
        /// 字典编码传入为空
        /// </summary>
        [ErrorCodeItemMetadata("字典编码传入为空.")]
        DictionaryCodeNonExist,
    }
}
