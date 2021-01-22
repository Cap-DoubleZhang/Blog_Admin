using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 系统角色表
    /// </summary>
    [Table("Sys_Role")]
    [Description("角色表")]
    public class SysRole : EntityExtend
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("RoleName")]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        [Column("RoleDesc")]
        public string RoleDesc { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        [Column("AdminFlag")]
        public AdminType AdminFlag { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        [Column("IsUse")]
        public UseType IsUse { get; set; }
    }
}
