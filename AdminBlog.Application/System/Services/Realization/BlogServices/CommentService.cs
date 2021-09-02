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
    /// 博客评论 业务
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class CommentService
    {
        #region 依赖注入
        private readonly IRepository<Blog> _blogRepository;
        private readonly IRepository<Comment> _commentRepository;
        public CommentService(IRepository<Blog> blogRepository, IRepository<Comment> commentRepository)
        {
            _blogRepository = blogRepository;
            _commentRepository = commentRepository;
        }
        #endregion

        #region 评论
        /// <summary>
        /// 根据博客获取分页评论列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("blogComments")]
        public async Task<PagedList<ResultBlogCommentDto>> GetPagedCommentByBlogAsync([FromQuery] SearchBlogCommonentDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<Comment, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
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
            }
            #endregion

            PagedList<Comment> commentDto = await _commentRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);

            return commentDto.Adapt<PagedList<ResultBlogCommentDto>>();
        }

        /// <summary>
        /// 根据博客获取分页评论列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("comments")]
        public async Task<PagedList<ResultCommentDto>> GetPagedCommentsAsync([FromQuery] SearchCommentDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<Comment, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
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

        ///// <summary>
        ///// 新增/编辑 评论
        ///// </summary>
        ///// <param name="saveDto"></param>
        ///// <returns></returns>
        //[HttpPost("comment")]
        //public async Task<bool> SaveCommentAsync(SaveCommentDto saveDto)
        //{
        //    //判断博客是否存在
        //    bool IsExist = await _blogRepository.AnyAsync(a => a.Id == saveDto.blogId && a.PublishType == BlogPublishTypeEnum.Publish);
        //    if (IsExist)
        //    {
        //        //新增评论信息
        //        Comment commentAdd = saveDto.Adapt<Comment>();
        //        commentAdd.CreatedTime = DateTime.UtcNow;
        //        await _commentRepository.InsertNowAsync(commentAdd);
        //    }
        //    else
        //    {
        //        throw Oops.Oh(CommentErrorCodeEnum.CommentBlogNonExist);
        //    }
        //    return true;
        //}

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
