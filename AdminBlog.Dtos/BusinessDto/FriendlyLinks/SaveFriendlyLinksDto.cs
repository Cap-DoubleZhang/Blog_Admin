using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存友链 Dto
    /// </summary>
    public class SaveFriendlyLinksDto : BaseSaveDto
    {
        /// <summary>
        /// 友链类型
        /// </summary>
        public LinkTypeEnum linkType { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空.")]
        public string name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [Required(ErrorMessage = "链接不能为空.")]
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
