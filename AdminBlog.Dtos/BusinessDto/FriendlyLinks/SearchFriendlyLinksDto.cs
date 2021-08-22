using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 搜索友链列表 Dto
    /// </summary>
    public class SearchFriendlyLinksDto : BaseSearchDto
    {
        /// <summary>
        /// 友链类型
        /// </summary>
        public int linkType { get; set; } = -1;
    }
}
