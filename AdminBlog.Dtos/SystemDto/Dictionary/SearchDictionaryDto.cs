using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索字典表Dto
    /// </summary>
    public class SearchDictionaryDto : BaseSearchDto
    {
        /// <summary>
        /// 字典编码
        /// </summary>
        public string code { get; set; }
    }
}
