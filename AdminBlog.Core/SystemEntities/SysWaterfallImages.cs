using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    [Table("Sys_WaterfallImages")]
    public class SysWaterfallImages : EntityExtend
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Src { get; set; }
    }
}
