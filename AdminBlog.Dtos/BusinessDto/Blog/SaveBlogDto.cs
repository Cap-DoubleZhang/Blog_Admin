using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存博客详情Dto
    /// </summary>
    public class SaveBlogDto : BaseSaveDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public string blogType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTimeOffset publishTime { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string synopsis { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string tags { get; set; }
        /// <summary>
        /// 发布类型
        /// </summary>
        public BlogPublishTypeEnum publishType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
    }
}
