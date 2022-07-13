using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminBlog.User;
using AdminBlog.SignalRApplication;
using Microsoft.AspNetCore.SignalR;

namespace AdminBlog.Application
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [DynamicApiController]
    [Route("api/[controller]")]
    public class UserService
    {
        #region 依赖注入
        private readonly IRepository<SysUser> _sysUserRepository;
        private readonly IRepository<SysUserInfo> _sysUserInfoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CurrentUser _currentUserService;
        private readonly CurrentUserInfoOptions _currentUserInfoSetting;
        private readonly UserInfoConstOptions _userInfoConstOptions;
        private readonly IRepository<SysRole> _sysRoleRepository;
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        private readonly IHubContext<SignalRHub> _hubContext;
        public UserService(IRepository<SysUser> sysUserRepository, IRepository<SysUserInfo> sysUserInfoRepository, CurrentUser currentUserService, IOptions<CurrentUserInfoOptions> currentUserInfoSetting, IOptions<UserInfoConstOptions> userInfoConstOptions, IRepository<SysRole> sysRoleRepository, IRepository<SysUserRole> sysUserRoleRepository, IHubContext<SignalRHub> hubContext)
        {
            _sysUserRepository = sysUserRepository;
            _sysUserInfoRepository = sysUserInfoRepository;
            _httpContextAccessor = App.GetService<IHttpContextAccessor>();
            _currentUserService = currentUserService;
            _currentUserInfoSetting = currentUserInfoSetting.Value;
            _userInfoConstOptions = userInfoConstOptions.Value;
            _sysRoleRepository = sysRoleRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
            _hubContext = hubContext;

        }
        #endregion

        #region 系统用户
        /// <summary>
        /// 获取系统用户分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("users")]
        public async Task<PagedList<ResultSysUserDto>> GetPagedSysUsersAsync([FromQuery] SearchSysUserDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<SysUser, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
                if (!string.IsNullOrWhiteSpace(keys[0]))
                {
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
                }
            }
            #endregion
            var users = await _sysUserRepository.DetachedEntities.Where(expression).OrderByDescending(a => a.CreatedTime)
                .GroupJoin(_sysUserInfoRepository.AsQueryable(), u => u.Id, ui => ui.UserID, (u, ui) => new
                {
                    u,
                    ui
                })
                .SelectMany(uui => uui.ui.DefaultIfEmpty(), (uui, ui) => new { uui.u, ui })
                .Select(a => new ResultSysUserDto
                {
                    Id = a.u.Id,
                    UserLoginName = a.u.UserLoginName,
                    Descripts = a.u.Descripts,
                    IsOnline = a.u.IsOnline,
                    LoginTimes = a.u.LoginTimes,
                    LastLoginTime = a.u.LastLoginTime,
                    LastLoginIP = a.u.LastLoginIP,
                    IsUse = a.u.IsUse,
                    userShowName = a.ui.UserShowName,
                    idCard = a.ui.IDCard,
                    headPortrait = a.ui.HeadPortrait,
                    phone = a.ui.Phone,
                    eMail = a.ui.EMail,
                    qq = a.ui.QQ,
                    weChat = a.ui.WeChat,
                    birthDate = a.ui.BirthDate,
                    CreatedTime = a.u.CreatedTime,
                }).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return users;
        }

        /// <summary>
        /// 根据token 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<ResultLoginUserDto> GetCurrentUserByToken()
        {
            if (_currentUserService == null || _currentUserService.UserId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);
            var userId = _currentUserService.UserId;
            if (userId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);

            //用户其他信息
            SysUserInfo sysUserInfo = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == userId);
            SysUser sysUser = await _currentUserService.GetCurrentUserAsync();
            //取用户角色表中查询数据
            long[] roleIds = await _sysUserRoleRepository.Where(a => a.UserID == sysUser.Id).Select(a => a.RoleID).ToArrayAsync();
            List<string> roles = await _sysRoleRepository.Where(a => roleIds.Contains(a.Id)).Select(a => a.RoleName).ToListAsync();
            roles.Add("Visiter");//ElementUIAdmin 需要起码一个角色，则给一个默认角色，此默认角色没有权限。
            ResultLoginUserDto resultLoginUserDto = new ResultLoginUserDto
            {
                name = sysUserInfo.UserShowName,
                avatar = sysUserInfo.HeadPortrait,
                introduction = sysUser.Descripts,
                roles = roles,
            };
            return resultLoginUserDto;
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public Task<bool> UserLogout()
        {
            //清空请求报文头
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = "";
            _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = "";
            return Task.FromResult(true);
        }

        /// <summary>
        /// 新增或更改系统用户
        /// </summary>
        /// <param name="sysUserDto"></param>
        /// <returns></returns>
        [HttpPost("user")]
        [UnitOfWork]
        public async Task<bool> SaveSysUserAsync(SaveSysUserDto sysUserDto)
        {
            if (sysUserDto.Id == 0)
            {
                //判断用户是否存在
                bool IsExist = await _sysUserRepository.AnyAsync(a => a.UserLoginName == sysUserDto.UserLoginName);
                if (IsExist)
                    throw Oops.Oh(UserErrorCodeEnum.UserNameExist);
                //新增用户登录信息
                SysUser sysUser = sysUserDto.Adapt<SysUser>();
                sysUser.UserPassword = EncryptHelper.DefaultPassword();
                var userAdd = await _sysUserRepository.InsertNowAsync(sysUser);
                //新增用户详情
                SysUserInfo sysUserInfo = sysUserDto.Adapt<SysUserInfo>();
                sysUserInfo.UserID = userAdd.Entity.Id;
                sysUserInfo.HeadPortrait = string.IsNullOrWhiteSpace(sysUserInfo.HeadPortrait) ? _userInfoConstOptions.HeadPortrait : sysUserInfo.HeadPortrait;
                await _sysUserInfoRepository.InsertNowAsync(sysUserInfo);
            }
            else
            {
                //判断用户是否存在
                bool IsExist = await _sysUserRepository.AnyAsync(a => a.Id == sysUserDto.Id && a.UserLoginName == sysUserDto.UserLoginName);
                if (IsExist)
                {
                    //更改用户信息
                    SysUser sysUser = sysUserDto.Adapt<SysUser>();
                    await _sysUserRepository.UpdateIncludeNowAsync(sysUser, new[] { nameof(sysUser.Descripts) }, true
                        );
                    //更改用户详情
                    SysUserInfo sysUserInfoNow = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == sysUser.Id);
                    SysUserInfo sysUserInfoSave = sysUserInfoNow.Adapt<SysUserInfo>();
                    sysUserInfoSave = sysUserDto.Adapt<SysUserInfo>();
                    sysUserInfoSave.Id = sysUserInfoNow.Id;
                    await _sysUserInfoRepository.UpdateExcludeNowAsync(sysUserInfoSave, new[] {
                        nameof(sysUserInfoSave.UserID),
                        nameof(sysUserInfoSave.CreateBy),
                        nameof(sysUserInfoSave.CreatedTime),
                        nameof(sysUserInfoSave.IsDeleted)}, true
                        );
                }
                else
                {
                    throw Oops.Oh(UserErrorCodeEnum.UserNonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <returns></returns>
        [HttpPut("resetpassword")]
        public async Task<bool> ResetUserPasswordAsync(SaveSysUserPasswordDto saveSysUserPasswordDto)
        {
            SysUser user = await _sysUserRepository.FindAsync(saveSysUserPasswordDto.Id) ?? new SysUser();
            if (user.Id <= 0)
                throw Oops.Oh(UserErrorCodeEnum.UserNonExist);
            //暂时不用
            //if (string.Compare(user.UserPassword, EncryptHelper.MD5Encode(saveSysUserPasswordDto.oldPassword)) != 0)
            //    throw Oops.Oh(UserErrorCodeEnum.ErrorOldPassword);
            if (string.Compare(EncryptHelper.MD5Encode(saveSysUserPasswordDto.newPassword.Trim()), EncryptHelper.MD5Encode(saveSysUserPasswordDto.reNewPassword.Trim())) != 0)
                throw Oops.Oh(UserErrorCodeEnum.NewPasswordAndRePasswordDifferent);

            user.UserPassword = EncryptHelper.MD5Encode(saveSysUserPasswordDto.newPassword);
            await _sysUserRepository.UpdateIncludeNowAsync(user, new[] { nameof(user.UserPassword) }, true
                );
            return true;
        }

        /// <summary>
        /// 修改当前登录用户密码
        /// </summary>
        /// <returns></returns>
        [HttpPut("updatepassword")]
        public async Task<bool> UpdateUserPasswordAsync(SaveSysUserPasswordDto saveSysUserPasswordDto)
        {
            SysUser user = await _currentUserService.GetCurrentUserAsync();
            if (user == null || user.Id <= 0)
                throw Oops.Oh(UserErrorCodeEnum.UserNonExist);
            if (string.IsNullOrWhiteSpace(saveSysUserPasswordDto.oldPassword) || saveSysUserPasswordDto.oldPassword.Length < 6)
                throw Oops.Oh("原密码不能为空，且必须大于6位.");
            if (string.Compare(user.UserPassword, EncryptHelper.MD5Encode(saveSysUserPasswordDto.oldPassword)) != 0)
                throw Oops.Oh(UserErrorCodeEnum.ErrorOldPassword);
            if (string.Compare(EncryptHelper.MD5Encode(saveSysUserPasswordDto.newPassword.Trim()), EncryptHelper.MD5Encode(saveSysUserPasswordDto.reNewPassword.Trim())) != 0)
                throw Oops.Oh(UserErrorCodeEnum.NewPasswordAndRePasswordDifferent);

            user.UserPassword = EncryptHelper.MD5Encode(saveSysUserPasswordDto.newPassword);
            await _sysUserRepository.UpdateIncludeNowAsync(user, new[] { nameof(user.UserPassword) }, true
                );
            return true;
        }

        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<string> UserLoginAsync([FromBody] SysUserLoginDto loginDto)
        {
            string MD5Password = EncryptHelper.MD5Encode(loginDto.password);
            SysUser userLogin = await _sysUserRepository.SingleOrDefaultAsync(a => a.UserPassword == MD5Password && a.UserLoginName == loginDto.username);
            if (userLogin == null || userLogin.Id <= 0)
                throw Oops.Oh(UserErrorCodeEnum.ErrorUserNameOrPassword);
            if (userLogin.IsUse == UseTypeEnum.NonUse)
                throw Oops.Oh(UserErrorCodeEnum.NonUse);

            userLogin.LoginTimes += 1;
            userLogin.LastLoginIP = App.HttpContext.GetLocalIpAddressToIPv4();
            userLogin.LastLoginTime = DateTime.Now;
            userLogin.IsOnline = OnlineTypeEnum.Online;
            await _sysUserRepository.UpdateAsync(userLogin);

            string accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { _currentUserInfoSetting.USERID,userLogin.Id },
                { _currentUserInfoSetting.USERNAME,userLogin.UserLoginName },
            });

            // 获取刷新 token
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 30); // 第二个参数是刷新 token 的有效期，默认三十天

            // 设置请求报文头
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = accessToken;
            _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;

            return accessToken;
        }

        /// <summary>
        /// 更新单个/批量用户是否可用
        /// </summary>
        /// <param name="updateSysUserUseDto"></param>
        /// <returns></returns>
        [HttpPut("userIsUse")]
        public async Task<bool> UpdateUserIsUseAsync(UpdateSysUserUseDto updateSysUserUseDto)
        {
            await _sysUserRepository.Context.BatchUpdate<SysUser>()
                .Set(a => a.IsUse, a => updateSysUserUseDto.IsUse)
                .Where(a => updateSysUserUseDto.ids.Contains(a.Id))
                .ExecuteAsync();
            return true;
        }

        /// <summary>
        /// 更新单个用户的头像
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut("userHeadPortrait")]
        public async Task<bool> UpdateUserHeadPortraitAsync(UpdateSysUserHeadPortraitDto updateDto)
        {
            var userId = _currentUserService.UserId;
            if (userId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);
            //更改用户详情
            SysUserInfo sysUserInfoNow = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == userId);
            if (sysUserInfoNow == null || sysUserInfoNow.Id <= 0)
                throw Oops.Oh(UserErrorCodeEnum.UserNonExist);
            sysUserInfoNow.HeadPortrait = updateDto.headPortrait;
            await _sysUserInfoRepository.UpdateIncludeNowAsync(sysUserInfoNow, new[] {
                        nameof(sysUserInfoNow.HeadPortrait),
                        nameof(sysUserInfoNow.UpdateBy),
                        nameof(sysUserInfoNow.UpdatedTime)}, true
                );
            return true;
        }

        /// <summary>
        /// 单个/批量删除用户
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteUserAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysUserRepository.Context.BatchUpdate<SysUser>()
                .Set(a => a.IsDeleted, a => true)
                .Where(a => baseBatchUpdateDto.ids.Contains(a.Id))
                .ExecuteAsync();
            return true;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("userinfo")]
        public async Task<ResultCurrentUserInfoDto> GetUserInfoAync()
        {
            var userId = _currentUserService.UserId;
            if (userId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);

            //用户其他信息
            SysUserInfo sysUserInfo = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == userId);
            SysUser sysUser = await _currentUserService.GetCurrentUserAsync();
            ResultCurrentUserInfoDto resultSysUserInfoDto = sysUserInfo.Adapt<ResultCurrentUserInfoDto>();
            resultSysUserInfoDto.userLoginName = sysUser.UserLoginName;
            resultSysUserInfoDto.introduction = sysUser.Descripts;
            return resultSysUserInfoDto;
        }
        #endregion
    }
}