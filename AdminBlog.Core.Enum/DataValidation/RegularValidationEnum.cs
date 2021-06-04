using Furion.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Core.Enum
{
    /// <summary>
    /// 数据校验 正则表达式 扩展类
    /// </summary>
    [ValidationType]
    public enum RegularValidationEnum
    {
        /// <summary>
        /// 验证所有的编码
        /// </summary>
        [ValidationItemMetadata(@"^\w$","编码只可由字母、数字、下划线组成.")]
        CodeType,
    }
}
