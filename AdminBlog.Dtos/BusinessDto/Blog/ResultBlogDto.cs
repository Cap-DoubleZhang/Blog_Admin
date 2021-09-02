﻿using AdminBlog.Core.Enum;
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
        public bool isTop { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool isAllowedComments { get; set; }
    }
}
