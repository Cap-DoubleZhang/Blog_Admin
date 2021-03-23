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
    /// 博客 业务
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class BlogService
    {
        #region 依赖注入
        private readonly IRepository<Blog> _blogRepository;
        public BlogService(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }
        #endregion

        #region 博客
        /// <summary>
        /// 获取分页博客列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultBlogDto>> GetPagedBlogAsync(SearchBlogDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<Blog, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(keys[0]))
            {
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.Title.Contains(item)
                                                      || x.BlogType.Contains(item)
                                                      || x.Synopsis.Contains(item)
                                                      || x.Tags.Contains(item)
                                                      || x.Content.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.Title.Contains(item)
                                                      || x.BlogType.Contains(item)
                                                      || x.Synopsis.Contains(item)
                                                      || x.Tags.Contains(item)
                                                      || x.Content.Contains(item));
                    }
                }
            }
            #endregion

            expression = expression.AndIf(searchDto.PublishBeginTime != null, a => a.CreatedTime >= searchDto.PublishBeginTime);
            expression = expression.AndIf(searchDto.PublishEndTime != null, a => a.CreatedTime <= searchDto.PublishEndTime);


            PagedList<Blog> pagedBlogs = await _blogRepository.Where(expression).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return pagedBlogs.Adapt<PagedList<ResultBlogDto>>();
        }

        /// <summary>
        /// 保存博客详情
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> SaveBlogAsync(SaveBlogDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //新增博客信息
                Blog blogAdd = saveDto.Adapt<Blog>();
                blogAdd.CreatedTime = DateTime.UtcNow;
                await _blogRepository.InsertNowAsync(blogAdd);
            }
            else
            {
                //判断博客是否存在
                bool IsExist = await _blogRepository.AnyAsync(a => a.Id == saveDto.Id);
                if (IsExist)
                {
                    //更改博客信息
                    Blog blog = saveDto.Adapt<Blog>();
                    blog.UpdatedTime = DateTime.UtcNow;
                    await _blogRepository.UpdateIncludeExistsNowAsync(blog, new[] {
                        nameof(blog.Title),
                        nameof(blog.BlogType),
                        nameof(blog.IsPublish),
                        nameof(blog.PublishTime),
                        nameof(blog.Cover),
                        nameof(blog.Synopsis),
                        nameof(blog.Tags),
                        nameof(blog.Content),
                        nameof(blog.UpdatedTime),}, true
                        );
                }
                else
                {
                    throw Oops.Oh(BlogErrorCodeEnum.NonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除博客
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteUserAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _blogRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new Blog { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(Blog.IsDeleted), nameof(Blog.UpdatedTime) });

            return true;
        }
        #endregion
    }
}
