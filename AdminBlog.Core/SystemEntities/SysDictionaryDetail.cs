using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core
{
    /// <summary>
    /// 字典明细值
    /// </summary>
    [Table("Sys_Dictionary_Detail")]
    public class SysDictionaryDetail : EntityExtend
    {
        /// <summary>
        /// 字典组编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 字典值编码
        /// </summary>
        public string DetailCode { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortIndex { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
