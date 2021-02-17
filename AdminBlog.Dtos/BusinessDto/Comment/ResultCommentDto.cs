using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 评论结果集Dto
    /// </summary>
    public class ResultCommentDto : BaseResultDto
    {
        /// <summary>
        /// 展示昵称
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 网站  站点
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string SystemVersion { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 根据IP地址 推断所在地
        /// </summary>
        public string IPHome { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 评论文章
        /// </summary>
        public string BlogTitle { get; set; }
    }
}
