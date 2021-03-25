using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using EFCore.BulkExtensions;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    /// <summary>
    /// 系统字典
    /// </summary>
    [DynamicApiController]
    [Route("/api/dictionary")]
    public class DictionaryService
    {
        #region 依赖注入
        private readonly IRepository<SysDictionary> _sysDictionaryRepository;
        public DictionaryService(IRepository<SysDictionary> sysDictionaryRepository)
        {
            _sysDictionaryRepository = sysDictionaryRepository;
        }
        #endregion

        #region 系统字典
        /// <summary>
        /// 获取系统字典分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("dictionaries")]
        public async Task<PagedList<ResultDictionaryDto>> GetPagedDictionariesAsync(SearchDirctionaryDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<SysDictionary, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(keys[0]))
            {
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.Name.Contains(item)
                                                      || x.Code.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.Name.Contains(item)
                                                      || x.Code.Contains(item));
                    }
                }
            }
            #endregion

            PagedList<SysDictionary> dictionaries = await _sysDictionaryRepository.Where(expression).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return dictionaries.Adapt<PagedList<ResultDictionaryDto>>();
        }

        /// <summary>
        /// 编辑/新增 系统字典
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("dictionary")]
        public async Task<bool> SaveDictionaryAsync(SaveDictionaryDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断字典是否存在
                bool IsExist = await _sysDictionaryRepository.AnyAsync(a => a.Name == saveDto.Name && a.Code == saveDto.Code);
                if (IsExist)
                    throw Oops.Oh(DictionaryErrorCodeEnum.DictionaryNameExist);
                //新增字典信息
                SysDictionary sysDictionaryAdd = saveDto.Adapt<SysDictionary>();
                sysDictionaryAdd.CreatedTime = DateTime.UtcNow;
                await _sysDictionaryRepository.InsertNowAsync(sysDictionaryAdd);
            }
            else
            {
                //判断字典 是否存在
                bool IsExist = await _sysDictionaryRepository.AnyAsync(a => a.Id == saveDto.Id && a.Name == saveDto.Name && a.Code == saveDto.Code);
                if (IsExist)
                {
                    //更改字典信息
                    SysDictionary sysDictionaryUpdate = saveDto.Adapt<SysDictionary>();
                    sysDictionaryUpdate.UpdatedTime = DateTime.UtcNow;
                    await _sysDictionaryRepository.UpdateIncludeExistsNowAsync(sysDictionaryUpdate, new[] { nameof(sysDictionaryUpdate.Value), nameof(sysDictionaryUpdate.UpdatedTime) }, true
                        );
                }
                else
                {
                    throw Oops.Oh(DictionaryErrorCodeEnum.DictionaryNonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除角色
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteDictionaryAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysDictionaryRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysDictionary { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysDictionary.IsDeleted), nameof(SysDictionary.UpdatedTime) });

            return true;
        }
        #endregion
    }
}
