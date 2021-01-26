using AdminBlog.Core;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    [DynamicApiController]
    public class SystemService
    {
        private readonly EFCoreRepository<SysUser> _sysUserRepository;
        public SystemService(EFCoreRepository<SysUser> sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<SysUser> GetSysUsersAsync()
        {
            return await _sysUserRepository.LastOrDefaultAsync();
        }

        public string Get()
        {
            return "你个大傻子";
        }
    }
}
