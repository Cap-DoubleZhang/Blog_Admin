using Furion;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AdminBlog.Common
{
    /// <summary>
    /// 字符串加密类
    /// </summary>
    public class EncryptHelper
    {
        #region 依赖注入密码配置类
        //private readonly PasswordSettingOptions passwordSetting;
        //public EncryptHelper()
        //{
        //}
        //public EncryptHelper(IOptions<PasswordSettingOptions> passwordOptions)
        //{
        //    passwordSetting = passwordOptions.Value;
        //}
        //static PasswordSettingOptions passwordSetting = App.GetOptions<PasswordSettingOptions>();
        #endregion

        /// <summary>
        /// 系统用户初始密码
        /// </summary>
        /// <returns></returns>
        public static string DefaultPassword()
        {
            PasswordSettingOptions passwordSetting = App.GetOptions<PasswordSettingOptions>();
            return MD5Encode(passwordSetting.DefaultPassword);
        }

        /// <summary>
        /// 根据加密类型判断使用怎样的加密方式（默认MD5 大写32位加密）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string MD5Encode(string source)
        {
            string newStr = "";
            PasswordSettingOptions passwordSetting = App.GetOptions<PasswordSettingOptions>();
            if (passwordSetting.EncryptType != 0)
            {
                using (var md5 = MD5.Create())
                {
                    var data = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                    StringBuilder builder = new StringBuilder();
                    // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("X2"));
                    }
                    if (passwordSetting.EncryptType == 1)
                    {
                        newStr = builder.ToString();
                    }
                    else if (passwordSetting.EncryptType == 2)
                    {
                        newStr = builder.ToString().Substring(passwordSetting.SubStart, passwordSetting.SubString);
                    }
                }
            }
            return newStr;
        }
    }
}
