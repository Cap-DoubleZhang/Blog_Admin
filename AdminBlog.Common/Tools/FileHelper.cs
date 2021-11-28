using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Common
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns>MD5值</returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                //using (var md5 = MD5.Create())
                //{
                //    var result = md5.ComputeHash(Encoding.UTF8.GetBytes(content));
                //    string md5Str = BitConverter.ToString(result);
                //    md5Str = md5Str.Replace("-", "");
                //    md5Str = isUpper ? md5Str : md5Str.ToLower();
                //    return is16 ? md5Str.Substring(8, 16) : md5Str;
                //}

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
