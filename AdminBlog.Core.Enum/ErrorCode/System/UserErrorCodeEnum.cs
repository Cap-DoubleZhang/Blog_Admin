using Furion.FriendlyException;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 系统错误码 提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum UserErrorCodeEnum
    {
        [ErrorCodeItemMetadata("Token 过期,请重新登录.")]
        TokenOverdue,

        /// <summary>
        /// 用户名或密码不正确
        /// </summary>
        [ErrorCodeItemMetadata("用户名或密码不正确.")]
        ErrorUserNameOrPassword,

        /// <summary>
        /// 该用户不存在或已被删除
        /// </summary>
        [ErrorCodeItemMetadata("该用户不存在或已被删除.")]
        UserNonExist,

        /// <summary>
        /// 原密码不正确
        /// </summary>
        [ErrorCodeItemMetadata("原密码不正确.")]
        ErrorOldPassword,

        /// <summary>
        /// 该用户名已存在
        /// </summary>
        [ErrorCodeItemMetadata("该用户名已存在.")]
        UserNameExist,

        /// <summary>
        /// 新密码与确认密码不一致
        /// </summary>
        [ErrorCodeItemMetadata("新密码与确认密码不一致.")]
        NewPasswordAndRePasswordDifferent,

        /// <summary>
        /// 该用户已被禁用
        /// </summary>
        [ErrorCodeItemMetadata("该用户已被禁用.")]
        NonUse,
    }
}
