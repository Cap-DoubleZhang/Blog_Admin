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
        private readonly IRepository<SysDictionaryDetail> _sysDictionaryDetailRepository;
        public DictionaryService(IRepository<SysDictionary> sysDictionaryRepository, IRepository<SysDictionaryDetail> sysDictionaryDetailRepository)
        {
            _sysDictionaryRepository = sysDictionaryRepository;
            _sysDictionaryDetailRepository = sysDictionaryDetailRepository;
        }
        #endregion

        #region 系统字典
        /// <summary>
        /// 获取系统字典分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("dictionaries")]
        public async Task<PagedList<ResultDictionaryDto>> GetPagedDictionariesAsync([FromQuery] SearchDictionaryDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<SysDictionary, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
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
                bool IsExist = await _sysDictionaryRepository.AnyAsync(a => a.Id == saveDto.Id && a.Code == saveDto.Code);
                if (IsExist)
                {
                    //更改字典信息
                    SysDictionary sysDictionaryUpdate = saveDto.Adapt<SysDictionary>();
                    await _sysDictionaryRepository.UpdateIncludeExistsNowAsync(sysDictionaryUpdate, new[] { nameof(sysDictionaryUpdate.Name), nameof(sysDictionaryUpdate.Remark) }, true
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
        [HttpDelete("dictionary")]
        public async Task<bool> DeleteDictionaryAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysDictionaryRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysDictionary { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysDictionary.IsDeleted), nameof(SysDictionary.UpdatedTime) });

            return true;
        }
        #endregion

        #region 系统字典明细
        /// <summary>
        /// 获取系统字典分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("dictionariesDetail")]
        public async Task<PagedList<ResultDictionaryDetailDto>> GetPagedDictionariesDetailAsync([FromQuery] SearchDictionaryDetailDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<SysDictionaryDetail, bool>> expression = t => true;
            if (string.IsNullOrWhiteSpace(searchDto.Code))
                throw Oops.Oh(DictionaryDetailErrorCodeEnum.DictionaryCodeNonExist);
            //搜索同组值
            expression = expression.And(x => x.Code == searchDto.Code);
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
                if (!string.IsNullOrWhiteSpace(keys[0]))
                {
                    foreach (var item in keys)
                    {
                        if (item == keys[0])
                        {
                            expression = expression.And(x => x.Value.Contains(item)
                                                          || x.DetailCode.Contains(item)
                                                          || x.Remark.Contains(item));
                        }
                        else
                        {
                            expression = expression.Or(x => x.Value.Contains(item)
                                                          || x.DetailCode.Contains(item)
                                                          || x.Remark.Contains(item));
                        }
                    }
                }
            }
            #endregion

            PagedList<SysDictionaryDetail> dictionariesDetail = await _sysDictionaryDetailRepository.Where(expression).OrderBy(a => a.SortIndex).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return dictionariesDetail.Adapt<PagedList<ResultDictionaryDetailDto>>();
        }

        /// <summary>
        /// 编辑/新增 系统字典明细
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("dictionaryDetail")]
        public async Task<bool> SaveDictionaryDetailAsync(SaveDictionaryDetailDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断字典是否存在
                bool IsExist = await _sysDictionaryDetailRepository.AnyAsync(a => a.Code == saveDto.code && a.DetailCode == saveDto.detailCode);
                if (IsExist)
                    throw Oops.Oh(DictionaryDetailErrorCodeEnum.DictionaryDetailCodeExist);
                //新增字典信息
                SysDictionaryDetail sysDictionaryDetailAdd = saveDto.Adapt<SysDictionaryDetail>();
                await _sysDictionaryDetailRepository.InsertNowAsync(sysDictionaryDetailAdd);
            }
            else
            {
                //判断字典 是否存在
                bool IsExist = await _sysDictionaryDetailRepository.AnyAsync(a => a.Id == saveDto.Id && a.Code == saveDto.code && a.DetailCode == saveDto.detailCode);
                if (IsExist)
                {
                    //更改字典信息
                    SysDictionaryDetail sysDictionaryDetailUpdate = saveDto.Adapt<SysDictionaryDetail>();
                    await _sysDictionaryDetailRepository.UpdateIncludeExistsNowAsync(sysDictionaryDetailUpdate, new[] { nameof(sysDictionaryDetailUpdate.SortIndex), nameof(sysDictionaryDetailUpdate.Value), nameof(sysDictionaryDetailUpdate.DetailCode), nameof(sysDictionaryDetailUpdate.Remark) }, true
                        );
                }
                else
                {
                    throw Oops.Oh(DictionaryDetailErrorCodeEnum.DictionaryDetailNonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除字典明细
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete("dictionaryDetail")]
        public async Task<bool> DeleteDictionaryDetailAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysDictionaryDetailRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysDictionaryDetail { IsDeleted = true }, new List<string> { nameof(SysDictionary.IsDeleted) });

            return true;
        }
        #endregion
    }
}
