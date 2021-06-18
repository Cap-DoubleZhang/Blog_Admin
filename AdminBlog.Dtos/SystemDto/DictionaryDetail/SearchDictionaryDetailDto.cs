using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索字典明细 Dto
    /// </summary>
    public class SearchDictionaryDetailDto : BaseSearchDto
    {
        /// <summary>
        /// 字典组编码
        /// </summary>
        public string code { get; set; }
    }
}
