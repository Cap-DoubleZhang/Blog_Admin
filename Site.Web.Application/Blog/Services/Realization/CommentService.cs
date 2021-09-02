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

namespace Site.Application
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
            expression.And(a => a.BlogId == searchDto.blogId);
            #endregion

            PagedList<Comment> commentDto = await _commentRepository.Where(expression).OrderBy(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);

            return commentDto.Adapt<PagedList<ResultBlogCommentDto>>();
        }

        /// <summary>
        /// 新增/编辑 评论
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("comment")]
        public async Task<bool> SaveCommentAsync(SaveCommentDto saveDto)
        {
            //判断博客是否存在
            Blog blog = await _blogRepository.SingleOrDefaultAsync(a => a.Id == saveDto.blogId && a.PublishType == BlogPublishTypeEnum.Publish);
            if (blog != null && blog.Id > 0)
            {
                if (!blog.IsAllowedComments)
                    throw Oops.Oh(CommentErrorCodeEnum.CommentBlogNonComment);
                //新增评论信息
                Comment commentAdd = saveDto.Adapt<Comment>();
                await _commentRepository.InsertNowAsync(commentAdd);
            }
            else
            {
                throw Oops.Oh(CommentErrorCodeEnum.CommentBlogNonExist);
            }
            return true;
        }
        #endregion
    }
}
