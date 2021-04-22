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
    [OptionsSettings("FilePath")]
    public class FilePathOptions : IConfigurableOptions
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string RealFilePath { get; set; }
    }
}
