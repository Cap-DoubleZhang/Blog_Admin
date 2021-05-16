using Furion.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 更改用户头像 Dto
    /// </summary>
    public class UpdateSysUserHeadPortraitDto
    {
        /// <summary>
        /// 头像的网络地址
        /// </summary>
        [Required(ErrorMessage = "头像地址不可为空.")]
        [DataValidation(ValidationTypes.Image, ErrorMessage = "请输入有效的头像地址.")]
        public string headPortrait { get; set; }
    }
}
