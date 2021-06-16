using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 字典集合结果集Dto
    /// </summary>
    public class ResultDictionaryDto : BaseResultDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 该明细下是否可多选
        /// </summary>
        public bool isCanMultiple { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string remark { get; set; }
    }
}
