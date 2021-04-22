using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 用户角色结果集 Dto
    /// </summary>
    public class ResultUserRoleDto : BaseResultDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string roleName { get; set; }
        /// <summary>
        /// 是否拥有该角色
        /// </summary>
        public bool promiss { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string roleDesc { get; set; }
    }
}
