using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 框架基础实体扩展，增加创建者、修改者
    /// </summary>
    [SkipScan]
    public class EntityExtend : Entity
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 上个修改者
        /// </summary>
        public int UpdateBy { get; set; }
    }
}
