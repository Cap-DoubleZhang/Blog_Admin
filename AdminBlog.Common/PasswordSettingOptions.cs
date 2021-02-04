using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Common
{
    /// <summary>
    /// 用户密码配置项
    /// </summary>
    [OptionsSettings("AppSettings:PasswordSetting")]
    public class PasswordSettingOptions : IConfigurableOptions
    {
        /// <summary>
        /// 密码加密方式
        /// </summary>
        public int EncryptType { get; set; }
        /// <summary>
        /// 密码截取开始索引
        /// </summary>
        public int SubStart { get; set; }
        /// <summary>
        /// 密码截取位数
        /// </summary>
        public int SubString { get; set; }
        /// <summary>
        /// 初始默认密码
        /// </summary>
        public string DefaultPassword { get; set; }
    }
}
