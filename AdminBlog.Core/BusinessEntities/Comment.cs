using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 博客评论表
    /// </summary>
    [Table("Comment")]
    [Description("博客评论列表")]
    public class Comment : EntityExtend
    {
        /// <summary>
        /// 所属博客ID
        /// </summary>
        public long BlogId { get; set; }
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
        [StringLength(500)]
        public string Value { get; set; }
    }
}
