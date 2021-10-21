using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 博客结果集Dto
    /// </summary>
    public class ResultBlogDto : BaseResultDto
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
        /// 发布类型
        /// </summary>
        public BlogPublishTypeEnum publishType { get; set; }
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
        /// 阅读数
        /// </summary>
        public int readingVolume { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int likes { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool isTop { get; set; }
        /// <summary>
        /// 内容（Markdown 格式）
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 内容（Html 格式）
        /// </summary>
        public string contentHtml { get; set; }
        /// <summary>
        /// 关键词（利于Seo）
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool isAllowedComments { get; set; }
        /// <summary>
        /// 定义的友好链接
        /// </summary>
        public string friendUrl { get; set; }
        /// <summary>
        /// 友好链接
        /// </summary>
        public string friendUrlStr
        {
            get
            {
                return $"{publishTime.Year}/{publishTime.Month}/{publishTime.Day}/{(!string.IsNullOrWhiteSpace(friendUrl) ? friendUrl : Id)}.html";
            }
        }
    }
}
