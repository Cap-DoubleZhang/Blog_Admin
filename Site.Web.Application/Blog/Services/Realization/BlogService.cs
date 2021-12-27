using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Site.Application
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

        /// <summary>
        /// 获取分页博客列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("blogs")]
        public async Task<PagedList<ResultSiteBlogsDto>> GetPagedBlogAsync([FromQuery] SearchBlogDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<Blog, bool>> expression = t => t.PublishType == BlogPublishTypeEnum.Publish;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
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
            }
            #endregion

            PagedList<Blog> pagedBlogs = await _blogRepository.Where(expression).OrderByDescending(a => a.IsTop).ThenByDescending(a => a.PublishTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return pagedBlogs.Adapt<PagedList<ResultSiteBlogsDto>>();
        }

        /// <summary>
        /// 获取博客详情
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{year}/{month}/{day}/{id}")]
        public async Task<ResultSiteBlogDto> GetBlogInfoAsync(int year, int month, int day, string id)
        {
            long idL = 0;
            if (new Regex(@"^\d+$").IsMatch(id))
            {
                idL = long.Parse(id);
            }
            Blog blog = await _blogRepository.SingleOrDefaultAsync(x => x.PublishTime.Year == year && x.PublishTime.Month == month &&
            x.PublishTime.Day == day && x.PublishType == BlogPublishTypeEnum.Publish && (x.FriendUrl == id || x.Id == idL));
            return blog.Adapt<ResultSiteBlogDto>();
        }
    }
}
