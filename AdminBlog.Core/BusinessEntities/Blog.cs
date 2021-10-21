using AdminBlog.Core.Enum;
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 博客表
    /// </summary>
    [Table("Blog")]
    [Description("博客列表")]
    public class Blog : EntityExtend
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public string BlogType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTimeOffset PublishTime { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Synopsis { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 阅读数
        /// </summary>
        public int ReadingVolume { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 发布类型
        /// </summary>
        public BlogPublishTypeEnum PublishType { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// 内容（Markdown 格式字符串）
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 内容（Html 格式字符串）
        /// </summary>
        public string ContentHtml { get; set; }
        /// <summary>
        /// 关键词（文章关键词，友好SEO）
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 友好链接，用于URL
        /// </summary>
        public string FriendUrl { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool IsAllowedComments { get; set; }
    }
}
