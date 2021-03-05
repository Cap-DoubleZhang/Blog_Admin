using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 登录时返回用户结果
    /// </summary>
    public class ResultLoginUserDto
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string introduction { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public List<string> roles { get; set; }
    }
}
