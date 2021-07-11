using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 查询角色菜单 Dto
    /// </summary>
    public class SearchRoleMenuDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Required(ErrorMessage = "请选择角色.")]
        public long roleId { get; set; }
    }
}
