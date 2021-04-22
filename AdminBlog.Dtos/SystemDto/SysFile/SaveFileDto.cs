using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存文件 Dto
    /// </summary>
    public class SaveFileDto : BaseSaveDto
    {
        ///// <summary>
        ///// 文件路径的子文件夹
        ///// </summary>
        //public string filePathName { get; set; }
        /// <summary>
        /// 文件本体
        /// </summary>
        [Required]
        [FileExtensions(Extensions = ".jpg,.png", ErrorMessage = "请上传JPG、PNG文件")]
        public IFormFile file { get; set; }
    }
}
