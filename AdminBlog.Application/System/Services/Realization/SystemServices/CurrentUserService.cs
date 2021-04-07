using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AdminBlog.Application
{
    /// <summary>
    /// 获取当前登录用户
    /// </summary>
    public class CurrentUserService : IScoped
    {
        private readonly IRepository<SysUser> _sysUserRepository; // 用户表仓储   
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CurrentUserInfoOptions _currentUserInfoSetting;
        public CurrentUserService(IRepository<SysUser> sysUserRepository, IOptions<CurrentUserInfoOptions> currentUserInfoSetting)
        {
            _sysUserRepository = sysUserRepository;
            _httpContextAccessor = App.GetService<IHttpContextAccessor>();
            _currentUserInfoSetting = currentUserInfoSetting.Value;
        }

        public long UserId
        {
            get => long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(_currentUserInfoSetting.USERID)?.Value);
        }

        public string UserName
        {
            get => _httpContextAccessor.HttpContext.User.FindFirst(_currentUserInfoSetting.USERNAME)?.Value;
        }

        public SysUser User
        {
            get => _sysUserRepository.Find(UserId);
        }

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<SysUser> GetCurrentUserAsync()
        {
            var user = await _sysUserRepository.FirstOrDefaultAsync(u => u.Id == UserId, true);
            return user ?? throw Oops.Oh(UserErrorCodeEnum.UserNonExist);
        }
    }
}
