using AdminBlog.Core.Enum;
using Furion.DataValidation;
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
        [Required(ErrorMessage = "登录名不能为空."), MinLength(5, ErrorMessage = "登录名长度不可小于5位字符.")
            , MaxLength(32, ErrorMessage = "登录名长度不可大于32位字符.")]
        [DataValidation(RegularValidationEnum.CodeType)]
        public string UserLoginName { get; set; }
        /// <summary>
        /// 用户描述
        /// </summary>
        [MaxLength(200, ErrorMessage = "描述长度不可大于200位字符.")]
        public string Descripts { get; set; }
        /// <summary>
        /// 用户展示名称（昵称）
        /// </summary>
        [Required(ErrorMessage = "昵称不能为空."), MaxLength(15, ErrorMessage = "昵称长度不可大于15位字符.")]
        public string UserShowName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataValidation(ValidationTypes.Image, ErrorMessage = "请输入有效的头像地址.", AllowNullValue = true, AllowEmptyStrings = true)]
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [DataValidation(ValidationTypes.PhoneOrTelNumber, ErrorMessage = "请输入有效的手机号码.", AllowNullValue = true, AllowEmptyStrings = true)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataValidation(ValidationTypes.EmailAddress, ErrorMessage = "请输入有效的邮件地址.", AllowNullValue = true, AllowEmptyStrings = true)]
        public string EMail { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataValidation(ValidationTypes.Date, ErrorMessage = "请输入有效的出生日期.", AllowNullValue = true, AllowEmptyStrings = true)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataValidation(ValidationTypes.IDCard, ErrorMessage = "请输入有效的身份证号.", AllowNullValue = true, AllowEmptyStrings = true)]
        public string IDCard { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }
    }
}
