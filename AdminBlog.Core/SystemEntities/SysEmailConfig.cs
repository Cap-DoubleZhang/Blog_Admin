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
    /// 个人邮件配置
    /// </summary>
    [Table("Sys_EmailConfig")]
    [Description("个人邮件配置")]
    public class SysEmailConfig : EntityExtend
    {
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 邮箱类型 选取字典中的邮箱类型
        /// </summary>
        public string EmailType { get; set; }
        /// <summary>
        /// SMTP地址
        /// </summary>
        public string SmtpUrl { get; set; }
        /// <summary>
        /// 发送的邮箱名（邮箱地址）
        /// </summary>
        public string EmailUserName { get; set; }
        /// <summary>
        /// 发送的邮箱密码（或独立密码）
        /// </summary>
        public string EmailPassword { get; set; }
    }
}
