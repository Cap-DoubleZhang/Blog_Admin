using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 友链结果集 Dto
    /// </summary>
    public class ResultFriendlyLinksDto : BaseResultDto
    {
        /// <summary>
        /// 友链类型
        /// </summary>
        public LinkTypeEnum linkType { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 简述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sortIndex { get; set; }
    }
}
