using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 文件集合 Dto
    /// </summary>
    public class ResultSysFileDto : BaseResultDto
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }

        /// <summary>
        /// 文件真实路径
        /// </summary>
        public string realPath { get; set; }

        /// <summary>
        /// 文件网络路径
        /// </summary>
        public string webPath
        {
            get
            {
                return $"{Id}{FileType}";
            }
            set
            {
                webPath = value;
            }
        }

        /// <summary>
        /// 文件大小（M）
        /// </summary>
        public long fileSize { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }
    }
}
