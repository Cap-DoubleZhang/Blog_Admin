using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 角色错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum RoleErrorCodeEnum
    {
        /// <summary>
        /// 该角色不存在
        /// </summary>
        [ErrorCodeItemMetadata("该角色不存在.")]
        NonExist,

        /// <summary>
        /// 该角色名已存在
        /// </summary>
        [ErrorCodeItemMetadata("该角色名已存在.")]
        RoleNameExist,
    }
}
