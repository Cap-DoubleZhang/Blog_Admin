using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 返回图片列表
    /// </summary>
    public class ResultSysImagesDto
    {
        public FileContentResult image { get; set; }
    }
}
