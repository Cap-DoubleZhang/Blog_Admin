using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 前台页面博客 Dto
    /// </summary>
    public class ResultSiteBlogDto
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
        /// 内容（html格式）
        /// </summary>
        public string contentHtml { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string tags { get; set; }
        /// <summary>
        /// 阅读数
        /// </summary>
        public int readingVolume { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int likes { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool isAllowedComments { get; set; }
        /// <summary>
        /// 关键词（利于文章SEO）
        /// </summary>
        public string keyword { get; set; }
    }
}
