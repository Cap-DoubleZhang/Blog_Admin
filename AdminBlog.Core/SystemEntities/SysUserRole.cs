using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.SystemEntities
{
    [Table("Sys_UserRole")]
    [Description("用户角色表")]
    public class SysUserRole : EntityExtend
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("UserID")]
        public long UserID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("RoleID")]
        public long RoleID { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        [Column("ValidFlag")]
        public ValidFlagType ValidFlag { get; set; }
    }
}
