using AdminBlog.Core;
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
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application.System.Services.Realization
{
    /// <summary>
    /// 博客 业务
    /// </summary>
    [DynamicApiController]
    public class BusinessService
    {
        #region 依赖注入
        private readonly IRepository<Blog> _blogRepository;
        private readonly IRepository<Comment> _commentRepository;
        public BusinessService(IRepository<Blog> blogRepository, IRepository<Comment> commentRepository)
        {
            _blogRepository = blogRepository;
            _commentRepository = commentRepository;
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
                    throw Oops.Oh("该数据不存在或已被删除.");
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

        #region 评论
        /// <summary>
        /// 获取分页评论列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultCommentDto>> GetPagedCommentAsync(SearchCommentDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<Comment, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(keys[0]))
            {
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.Value.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.Value.Contains(item));
                    }
                }
            }
            #endregion

            expression = expression.AndIf(searchDto.beginTime != null, a => a.CreatedTime >= searchDto.beginTime);
            expression = expression.AndIf(searchDto.endTime != null, a => a.CreatedTime <= searchDto.endTime);

            PagedList<ResultCommentDto> commentDto = await _commentRepository.Where(expression).GroupJoin(_blogRepository.AsQueryable(), c => c.BlogId, b => b.Id, (c, b) => new
            {
                c,
                b,
            }).SelectMany(cb => cb.b.DefaultIfEmpty(), (cb, b) => new ResultCommentDto
            {
                ShowName = cb.c.ShowName,
                HeadPortrait = cb.c.HeadPortrait,
                EMail = cb.c.HeadPortrait,
                Site = cb.c.Site,
                Browser = cb.c.Browser,
                SystemVersion = cb.c.SystemVersion,
                IP = cb.c.IP,
                IPHome = cb.c.IPHome,
                QQ = cb.c.QQ,
                Value = cb.c.Value,
                BlogTitle = cb.b.FirstOrDefault().Title,
            }).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);

            return commentDto;
        }

        [HttpPost]
        public async Task<bool> SaveCommentAsync(SaveCommentDto saveDto)
        {
            //判断博客是否存在
            bool IsExist = await _blogRepository.AnyAsync(a => a.Id == saveDto.blogId && a.IsPublish == true);
            if (IsExist)
            {
                //新增博客信息
                Comment commentAdd = saveDto.Adapt<Comment>();
                commentAdd.CreatedTime = DateTime.UtcNow;
                await _commentRepository.InsertNowAsync(commentAdd);
            }
            else
            {
                throw Oops.Oh("该数据不存在,无法评论.");
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除评论
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteCommentAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _commentRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new Comment { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(Comment.IsDeleted), nameof(Comment.UpdatedTime) });

            return true;
        }
        #endregion
    }
}
