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
    public class ResultSysUserInfoDto
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
        /// 简介
        /// </summary>
        public string introduction { get; set; }
    }
}
