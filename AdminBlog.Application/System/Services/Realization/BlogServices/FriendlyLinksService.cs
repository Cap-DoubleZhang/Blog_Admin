using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
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
    /// 友链/公告 业务
    /// </summary>
    [DynamicApiController]
    [Route("/api/link")]
    public class FriendlyLinksService
    {
        #region 依赖注入
        private readonly IRepository<FriendlyLinks> _friendlyLinksRepository;
        public FriendlyLinksService(IRepository<FriendlyLinks> friendlyLinksRepository)
        {
            _friendlyLinksRepository = friendlyLinksRepository;
        }
        #endregion

        #region 友链
        /// <summary>
        /// 获取分页友链/公告列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("links")]
        public async Task<PagedList<ResultFriendlyLinksDto>> GetPagedBlogAsync([FromQuery] SearchFriendlyLinksDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<FriendlyLinks, bool>> expression = t => true;
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
                                                          || x.Url.Contains(item)
                                                          || x.Description.Contains(item));
                        }
                        else
                        {
                            expression = expression.Or(x => x.Name.Contains(item)
                                                          || x.Url.Contains(item)
                                                          || x.Description.Contains(item));
                        }
                    }
                }
            }
            #endregion

            PagedList<FriendlyLinks> pagedLinks = await _friendlyLinksRepository.Where(expression).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return pagedLinks.Adapt<PagedList<ResultFriendlyLinksDto>>();
        }

        /// <summary>
        /// 保存友链详情
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("link")]
        public async Task<bool> SaveFriendlyLinkAsync([FromBody] SaveFriendlyLinksDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //新增友链信息
                FriendlyLinks linkAdd = saveDto.Adapt<FriendlyLinks>();
                await _friendlyLinksRepository.InsertNowAsync(linkAdd);
            }
            else
            {
                //判断友链是否存在
                bool IsExist = await _friendlyLinksRepository.AnyAsync(a => a.Id == saveDto.Id);
                if (IsExist)
                {
                    //更改友链信息
                    FriendlyLinks link = saveDto.Adapt<FriendlyLinks>();
                    await _friendlyLinksRepository.UpdateIncludeNowAsync(link, new[] {
                        nameof(link.LinkType),
                        nameof(link.Name),
                        nameof(link.Url),
                        nameof(link.Image),
                        nameof(link.Description),
                        nameof(link.SortIndex),
                    }, true);
                }
                else
                {
                    throw Oops.Oh(FriendlyLinksCodeEnum.LinkNonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除友链
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete("link")]
        public async Task<bool> DeleteBlogAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _friendlyLinksRepository.Context.BatchUpdate<FriendlyLinks>()
                                           .Set(a => a.IsDeleted, a => true)
                                           .Where(a => baseBatchUpdateDto.ids.Contains(a.Id))
                                           .ExecuteAsync();
            return true;
        }
        #endregion
    }
}
