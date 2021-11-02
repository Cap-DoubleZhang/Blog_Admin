using AdminBlog.Core.Enum;
using Furion.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "标题不能为空.")]
        public string title { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public string blogType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTimeOffset publishTime { get; set; } = DateTimeOffset.UtcNow;
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
        /// 发布状态
        /// </summary>
        public BlogPublishTypeEnum publishType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "内容不能为空.")]
        public string content { get; set; }
        /// <summary>
        /// 内容（Html格式）
        /// </summary>
        public string contentHtml { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 友好链接
        /// </summary>
        [RegularExpression("^[A-Za-z0-9_-]+$")]
        public string friendUrl { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool isTop { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool isAllowedComments { get; set; }
    }
}
