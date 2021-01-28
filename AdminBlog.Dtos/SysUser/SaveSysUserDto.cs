using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存系统用户Dto
    /// </summary>
    public class SaveSysUserDto : BaseSaveDto
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空."), MinLength(5, ErrorMessage = "长度不可小于5位.")
            , MaxLength(32, ErrorMessage = "长度不可大于32位.")]
        public string UserLoginName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        public string Descripts { get; set; }
    }
}
