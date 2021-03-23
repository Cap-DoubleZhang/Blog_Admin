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
    [OptionsSettings("CurrentUserInfo")]
    public class CurrentUserInfoOptions : IConfigurableOptions
    {
        /// <summary>
        /// USER ID
        /// </summary>
        public string USERID { get; set; }
        /// <summary>
        /// USER NAME
        /// </summary>
        public string USERNAME { get; set; }
    }
}
