using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 前台页面博客结果集 Dto
    /// </summary>
    public class ResultSiteBlogsDto
    {
        public long id { get; set; }
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
                return $"{publishTime.Year}/{publishTime.Month}/{publishTime.Day}/{(!string.IsNullOrWhiteSpace(friendUrl) ? friendUrl : id)}.html";
            }
        }
    }
}
