using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Common
{
    /// <summary>
    /// 当前登录用户标识常量
    /// </summary>
    [OptionsSettings("UserInfoConst")]
    public class UserInfoConstOptions : IConfigurableOptions
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
    }
}
