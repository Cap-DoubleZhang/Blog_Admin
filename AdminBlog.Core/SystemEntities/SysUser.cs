using AdminBlog.Core.Enum;
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
    /// 用户登录信息表
    /// </summary>
    [Table("Sys_User")]
    [Description("账号")]
    public class SysUser : EntityExtend
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        [StringLength(32)]
        [Column("UserLoginName")]
        public string UserLoginName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(100)]
        [Column("UserPassword")]
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        [StringLength(200)]
        [Column("Descripts")]
        public string Descripts { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        [Column("IsOnline")]
        public OnlineTypeEnum IsOnline { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Column("LoginTimes")]
        public int LoginTimes { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Column("LastLoginTime")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登录IP
        /// </summary>
        [Column("LastLoginIP")]
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        [Column("IsUse")]
        public UseTypeEnum IsUse { get; set; }
    }
}
