using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 系统用户结果集Dto
    /// </summary>
    public class ResultSysUserDto : BaseResultDto
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserLoginName { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        public string Descripts { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public OnlineTypeEnum IsOnline { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LoginTimes { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public UseTypeEnum IsUse { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string userShowName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string headPortrait { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string eMail { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string weChat { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthDate { get; set; }
    }
}
