using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 用户搜索具有的角色
    /// </summary>
    public class SearchUserRoleDto
    {
        /// <summary>
        /// 用户的ID
        /// </summary>
        [Required(ErrorMessage = "必要参数为空.")]
        public long id { get; set; }
    }
}
