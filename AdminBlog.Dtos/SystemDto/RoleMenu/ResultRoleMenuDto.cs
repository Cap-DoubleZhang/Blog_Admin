using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    /// <summary>
    /// 角色菜单结果集Dto
    /// </summary>
    public class ResultRoleMenuDto : BaseResultDto
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long menuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }
        /// <summary>
        /// 上级菜单
        /// </summary>
        public long parentId { get; set; }
        /// <summary>
        /// 该角色是否拥有权限
        /// </summary>
        public bool promiss { get; set; }
        /// <summary>
        /// 下级角色
        /// </summary>
        public List<ResultRoleMenuDto> children { get; set; }
    }
}
