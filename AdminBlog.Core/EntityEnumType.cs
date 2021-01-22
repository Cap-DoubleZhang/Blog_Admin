using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 用户是否在线
    /// </summary>
    public enum OnlineType
    {
        /// <summary>
        /// 不在线
        /// </summary>
        NonOnline = 0,
        /// <summary>
        /// 在线
        /// </summary>
        Online = 1,
    }

    /// <summary>
    /// 该条数据是否被禁用
    /// </summary>
    public enum ValidFlagType
    {
        /// <summary>
        /// 有效
        /// </summary>
        Effective = 0,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid = 1,
    }

    /// <summary>
    /// 该条数据是否被禁用
    /// </summary>
    public enum UseType
    {
        /// <summary>
        /// 可用
        /// </summary>
        Active = 0,
        /// <summary>
        /// 禁用
        /// </summary>
        NonUse = 1,
    }

    /// <summary>
    /// 是否为管理员
    /// </summary>
    public enum AdminType
    {
        /// <summary>
        /// 是管理员
        /// </summary>
        Yes = 1,
        /// <summary>
        /// 不是管理员
        /// </summary>
        No = 0,
    }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 页面
        /// </summary>
        Page = 0,
        /// <summary>
        /// 按钮
        /// </summary>
        Button = 1
    }
}
