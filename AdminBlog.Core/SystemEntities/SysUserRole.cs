using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    [Table("Sys_UserRole")]
    [Description("用户角色表")]
    public class SysUserRole : EntityExtend, IEntitySeedData<SysUserRole>
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
        /// 增加种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysUserRole> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<SysUserRole>
            {
                new SysUserRole { Id = 156951674213412, UserID = 156951674213412, RoleID =156951674213412,CreatedTime=DateTimeOffset.UtcNow },
            };
        }
    }
}
