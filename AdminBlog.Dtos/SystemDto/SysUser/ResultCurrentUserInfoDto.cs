using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 当前登录用户信息 Dto
    /// </summary>
    public class ResultCurrentUserInfoDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string userLoginName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string userShowName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string headPortrait { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string idCard { get; set; }
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
        /// <summary>
        /// 简介
        /// </summary>
        public string introduction { get; set; }
    }
}
