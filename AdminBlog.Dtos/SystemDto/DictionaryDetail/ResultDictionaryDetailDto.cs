using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 字典明细结果集 Dto
    /// </summary>
    public class ResultDictionaryDetailDto : BaseResultDto
    {
        /// <summary>
        /// 字典组编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 字典明细编码
        /// </summary>
        public string detailCode { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sortIndex { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
