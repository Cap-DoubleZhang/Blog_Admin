using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存评论Dto
    /// </summary>
    public class SaveCommentDto
    {
        public long blogId { get; set; }
        /// <summary>
        /// 展示昵称
        /// </summary>
        public string showName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string headPortrait { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 网站  站点
        /// </summary>
        public string site { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string browser { get; set; }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string systemVersion { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 根据IP地址 推断所在地
        /// </summary>
        public string iPHome { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// 评论内容(需进行脱敏处理)
        /// </summary>
        [SensitiveDetection('*')]
        public string value { get; set; }
    }
}
