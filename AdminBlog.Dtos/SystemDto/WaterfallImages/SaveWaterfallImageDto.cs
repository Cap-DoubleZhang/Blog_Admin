using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存瀑布流图片 Dto
    /// </summary>
    public class SaveWaterfallImageDto : BaseSaveDto
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        [Required(ErrorMessage = "请上传图片")]
        [FileExtensions(Extensions = ".jpg,.png,.bmp,.tif,.gif,.pcx,.psd", ErrorMessage = "仅支持上传.jpg|.png|.bmp|.tif|.gif|.pcx|.psd类型的图片.")]
        public string src { get; set; }
    }
}
