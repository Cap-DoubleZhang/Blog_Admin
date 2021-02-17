using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    public class SaveSysRoleDto : BaseSaveDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空.")]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDesc { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public AdminTypeEnum AdminFlag { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public UseTypeEnum IsUse { get; set; }
    }
}
