using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存系统字段Dto
    /// </summary>
    public class SaveDictionaryDto : BaseSaveDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空.")]
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空.")]
        public string Code { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "值不能为空.")]
        public string Value { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
