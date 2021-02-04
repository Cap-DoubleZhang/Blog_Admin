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
    /// 用户信息详情表
    /// </summary>
    [Table("Sys_UserInfo")]
    [Description("用户信息详情表")]
    public class SysUserInfo : EntityExtend
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("UserID")]
        public long UserID { get; set; }

        /// <summary>
        /// 用户展示名称（昵称）
        /// </summary>
        [Column("UserShowName")]
        public string UserShowName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Column("HeadPortrait")]
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("EMail")]
        public string EMail { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Column("BirthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("IDCard")]
        public string IDCard { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [Column("QQ")]
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [Column("WeChat")]
        public string WeChat { get; set; }
    }
}
