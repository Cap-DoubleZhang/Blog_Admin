using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存字典明细 Dto
    /// </summary>
    public class SaveDictionaryDetailDto : BaseSaveDto
    {
        /// <summary>
        /// 字典组编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空.")]
        public string code { get; set; }
        /// <summary>
        /// 字典明细编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空.")]
        [DataValidation(RegularValidationEnum.CodeType)]
        public string detailCode { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sortIndex { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "值不能为空.")]
        public string value { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
