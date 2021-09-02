using AdminBlog.Core;
using AdminBlog.Dtos;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application
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

        /// <summary>
        /// 获取分页友链/公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("links")]
        public async Task<List<ResultFriendlyLinksDto>> GetLinksAsync()
        {
            List<FriendlyLinks> lst = await _friendlyLinksRepository.AsQueryable().ToListAsync();
            return lst.Adapt<List<ResultFriendlyLinksDto>>();
        }
    }
}
