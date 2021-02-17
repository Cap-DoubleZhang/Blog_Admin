using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 保存角色菜单Dto
    /// </summary>
    public class SaveRoleMenuDto : BaseSaveDto
    {
        /// <summary>
        /// 菜单Id集合
        /// </summary>
        [Required(ErrorMessage = "请选择角色菜单.")]
        public int[] menuIds { get; set; }
    }
}
