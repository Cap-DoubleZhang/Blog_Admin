﻿using Furion.ConfigurableOptions;
using Microsoft.Extensions.Configuration;
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
    [OptionsSettings("PasswordSetting")]
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
        ///// <summary>
        ///// 配置默认项 
        ///// </summary>
        ///// <param name="options"></param>
        ///// <param name="configuration"></param>
        //public void PostConfigure(PasswordSettingOptions options, IConfiguration configuration)
        //{
        //    options.EncryptType = options.EncryptType == 0 ? 2 : options.EncryptType;
        //    options.SubStart = options.SubStart == 0 ? 6 : options.SubStart;
        //    options.SubString = options.SubString == 0 ? 20 : options.SubString;
        //    options.DefaultPassword ??= "000000";
        //}
    }
}
