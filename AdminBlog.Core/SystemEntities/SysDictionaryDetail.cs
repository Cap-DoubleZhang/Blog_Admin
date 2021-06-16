using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBlog.Core
{
    /// <summary>
    /// 字典明细值
    /// </summary>
    [Table("Sys_Dictionary_Detail")]
    public class SysDictionaryDetail : EntityExtend, IEntitySeedData<SysDictionaryDetail>
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

        /// <summary>
        /// 增加种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysDictionaryDetail> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<SysDictionaryDetail>
            {
                new SysDictionaryDetail { Id = 160774000443461, Code = "BlogType", DetailCode = "InformalEssay", Value = "随笔",SortIndex = 0,CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 160776633155653, Code = "BlogType", DetailCode = "Article", Value = "文章", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022405, Code = "EmailType", DetailCode = "TencentCompanyEmail", Value = "腾讯企业邮箱", SortIndex = 0, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022406, Code = "EmailType", DetailCode = "163FreeEmail", Value = "163免费邮箱", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022407, Code = "BlogLabel", DetailCode = "Java", Value = "Java", SortIndex = 0, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022408, Code = "BlogLabel", DetailCode = "C#", Value = "C#", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022409, Code = "BlogLabel", DetailCode = "NET Core", Value = "NET Core", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022410, Code = "BlogLabel", DetailCode = "JS", Value = "JS", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
                new SysDictionaryDetail { Id = 161765323022411, Code = "BlogLabel", DetailCode = "Vue", Value = "Vue", SortIndex = 1, CreatedTime = DateTimeOffset.UtcNow },
            };
        }
    }
}
