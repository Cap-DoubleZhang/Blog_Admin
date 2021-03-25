using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 菜单错误码  提示用户操作反馈
    /// </summary>
    [ErrorCodeType]
    public enum SysMenuErrorCodeEnum
    {
        /// <summary>
        /// 该菜单数据不存在或已被删除
        /// </summary>
        [ErrorCodeItemMetadata("该菜单数据不存在或已被删除.")]
        MenuNonExist,

        /// <summary>
        /// 该菜单名称已存在
        /// </summary>
        [ErrorCodeItemMetadata("该菜单名称已存在.")]
        MenuNameExist,
    }
}
