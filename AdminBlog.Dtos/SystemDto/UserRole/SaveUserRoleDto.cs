using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存用户角色Dto
    /// </summary>
    public class SaveUserRoleDto : BaseSaveDto
    {
        /// <summary>
        /// 用户角色 Id集合
        /// </summary>
        [Required(ErrorMessage = "请选择用户角色.")]
        public int[] roleIds { get; set; }
    }
}
