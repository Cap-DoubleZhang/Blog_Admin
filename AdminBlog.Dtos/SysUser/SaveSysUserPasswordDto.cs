using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 更改用户密码Dto
    /// </summary>
    public class SaveSysUserPasswordDto : BaseSaveDto
    {
        /// <summary>
        /// 原密码
        /// </summary>
        [Required(ErrorMessage = "原密码不可为空."), MinLength(6, ErrorMessage = "原密码不可小于6个字符.")]
        public string oldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "新密码不可为空."), MinLength(6, ErrorMessage = "新密码不可小于6个字符.")]
        public string newPassword { get; set; }
        /// <summary>
        /// 确定新密码
        /// </summary>
        [Required(ErrorMessage = "确认密码不可为空."), MinLength(6, ErrorMessage = "确认密码不可小于6个字符.")]
        public string reNewPassword { get; set; }
    }
}
