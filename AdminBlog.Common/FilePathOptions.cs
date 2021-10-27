using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Common
{
    /// <summary>
    /// 上传图片相关配置
    /// </summary>
    [OptionsSettings("FilePath")]
    public class FilePathOptions : IConfigurableOptions
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string RealFilePath { get; set; }

        /// <summary>
        /// 文件上传本地的链接前缀
        /// </summary>
        public string UploadLocalhost { get; set; }
    }
}
