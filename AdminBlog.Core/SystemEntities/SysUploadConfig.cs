using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.SystemEntities
{
    /// <summary>
    /// 上传文件
    /// 
    /// </summary>
    public class SysUploadConfig
    {
        /// <summary>
        /// 上传位置（本地、腾讯云、阿里云）
        /// </summary>
        public int Flag { get; set; }
        /// <summary>
        /// 密钥（以下为密钥查看链接）
        /// 腾讯云：https://console.cloud.tencent.com/cam/capi
        /// </summary>
        public string SecretId { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 是否为默认上传地址
        /// </summary>
        public int IsDefault { get; set; }
    }
}
