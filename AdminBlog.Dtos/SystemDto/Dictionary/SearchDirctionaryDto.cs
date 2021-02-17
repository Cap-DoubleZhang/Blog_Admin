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
    public class SearchDirctionaryDto : BaseSearchDto
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
