using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{

    [Table("Sys_File")]
    public class SysFile : EntityExtend
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 真实文件路径
        /// </summary>
        public string RealPath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 文件下载次数
        /// </summary>
        public int DownTimes { get; set; }
    }
}
