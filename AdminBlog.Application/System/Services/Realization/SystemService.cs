using AdminBlog.Application.System;
using AdminBlog.Core;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    [DynamicApiController]
    public class SystemService
    {
        #region 依赖注入
        private readonly IRepository<SysUser> _sysUserRepository;
        public SystemService(IRepository<SysUser> sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }
        #endregion

        #region 系统用户
        /// <summary>
        /// 获取系统用户分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultDto>> GetSysUsersAsync(SearchDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Split(' ');
            Expression<Func<SysUser, bool>> expression = t => true;
            foreach (var item in keys)
            {
                if (item == keys[0])
                {
                    expression = expression.And(x => x.UserLoginName.Contains(item)
                                                  || x.Descripts.Contains(item)
                                                  || x.LastLoginIP.Contains(item));
                }
                else
                {
                    expression = expression.Or(x => x.UserLoginName.Contains(item)
                                                  || x.Descripts.Contains(item)
                                                  || x.LastLoginIP.Contains(item));
                }
            }
            #endregion
            PagedList<SysUser> sysUsers = await _sysUserRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return sysUsers.Adapt<PagedList<ResultDto>>();
        }

        #endregion
    }
}
