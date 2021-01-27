using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application.System
{
    /// <summary>
    /// 系统用户结果集Dto
    /// </summary>
    public class ResultDto : BaseResultDto
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
        public OnlineType IsOnline { get; set; }
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
        public UseType IsUse { get; set; }
    }
}
