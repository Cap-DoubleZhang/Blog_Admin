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
    /// <summary>
    /// 字典表
    /// </summary>
    [Table("Sys_Dictionary")]
    [Description("词典")]
    public class SysDictionary : EntityExtend, IEntitySeedData<SysDictionary>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述/备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 增加种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysDictionary> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<SysDictionary>
            {
                new SysDictionary { Id = 160774000443461, Code = "BlogType", Name = "博客类型",CreatedTime=DateTimeOffset.UtcNow },
                new SysDictionary { Id = 160776633155653, Code = "EmailType", Name = "邮箱类型",CreatedTime=DateTimeOffset.UtcNow },
            };
        }
    }
}
