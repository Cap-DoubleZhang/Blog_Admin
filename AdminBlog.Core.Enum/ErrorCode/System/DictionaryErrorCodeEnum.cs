using Furion.FriendlyException;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 系统字典错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum DictionaryErrorCodeEnum
    {
        /// <summary>
        /// 该字典数据不存在或已被删除
        /// </summary>
        [ErrorCodeItemMetadata("该字典数据不存在或已被删除.")]
        NonExist,

        /// <summary>
        /// 该字典名称已存在
        /// </summary>
        [ErrorCodeItemMetadata("该字典名称已存在.")]
        NameExist,
    }
}
