﻿using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 框架基础实体扩展，增加创建者、修改者
    /// </summary>
    [SkipScan]
    public class EntityExtend : Entity<long>
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public override long Id { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public long? CreateBy { get; set; }
        /// <summary>
        /// 上个修改者
        /// </summary>
        public long? UpdateBy { get; set; }
    }
}
