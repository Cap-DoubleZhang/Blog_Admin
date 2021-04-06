﻿using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using EFCore.BulkExtensions;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        private readonly CurrentUserService _currentUserService;
        private readonly CurrentUserInfoOptions _currentUserInfoSetting;
        public UserService(IRepository<SysUser> sysUserRepository, IRepository<SysUserInfo> sysUserInfoRepository, CurrentUserService currentUserService, IOptions<CurrentUserInfoOptions> currentUserInfoSetting)
        {
            _sysUserRepository = sysUserRepository;
            _sysUserInfoRepository = sysUserInfoRepository;
            _httpContextAccessor = App.GetService<IHttpContextAccessor>();
            _currentUserService = currentUserService;
            _currentUserInfoSetting = currentUserInfoSetting.Value;
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
            var userId = _currentUserService.UserId;
            if (userId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);

            //用户其他信息
            SysUserInfo sysUserInfo = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == userId);

            //取用户角色表中查询数据
            List<string> roles = new List<string>()
            {
                new string("admin"),
            };
            ResultLoginUserDto resultLoginUserDto = new ResultLoginUserDto
            {
                name = string.IsNullOrWhiteSpace(sysUserInfo.UserShowName) ? "admin" : sysUserInfo.UserShowName,
                avatar = string.IsNullOrWhiteSpace(sysUserInfo.HeadPortrait) ? "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024" : sysUserInfo.HeadPortrait,
                introduction = "",
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
                    await _sysUserRepository.UpdateIncludeExistsNowAsync(sysUser, new[] { nameof(sysUser.Descripts) }, true
                        );
                    //更改用户详情
                    SysUserInfo sysUserInfoNow = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == sysUser.Id);
                    SysUserInfo sysUserInfoSave = sysUserInfoNow.Adapt<SysUserInfo>();
                    sysUserInfoSave = sysUserDto.Adapt<SysUserInfo>();
                    sysUserInfoSave.Id = sysUserInfoNow.Id;
                    await _sysUserInfoRepository.UpdateExcludeExistsNowAsync(sysUserInfoSave, new[] {
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
        /// 更改用户密码
        /// </summary>
        /// <returns></returns>
        [HttpPut("userpassword")]
        public async Task<bool> UpdateUserPasswordAsync(SaveSysUserPasswordDto saveSysUserPasswordDto)
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
            await _sysUserRepository.UpdateIncludeExistsNowAsync(user, new[] { nameof(user.UserPassword) }, true
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
            await _sysUserRepository.Where(a => updateSysUserUseDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysUser { IsUse = updateSysUserUseDto.IsUse, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysUser.IsUse), nameof(SysUser.UpdatedTime) });
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
            await _sysUserRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysUser { IsDeleted = true, UpdatedTime = DateTimeOffset.Now }, new List<string> { nameof(SysUser.IsDeleted), nameof(SysUser.UpdatedTime) });

            return true;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("userinfo")]
        public async Task<ResultSysUserInfoDto> GetUserInfoAync()
        {
            var userId = _currentUserService.UserId;
            if (userId <= 0)
                throw Oops.Oh(UserErrorCodeEnum.TokenOverdue);

            //用户其他信息
            SysUserInfo sysUserInfo = await _sysUserInfoRepository.SingleOrDefaultAsync(a => a.UserID == userId);
            SysUser sysUser = await _sysUserRepository.SingleOrDefaultAsync(a => a.Id == userId);
            ResultSysUserInfoDto resultSysUserInfoDto = sysUser.Adapt<ResultSysUserInfoDto>();
            resultSysUserInfoDto.headPortrait = string.IsNullOrWhiteSpace(resultSysUserInfoDto.headPortrait) ? "https://p1.music.126.net/RVcAosDFn4uLeSZ_byDGdg==/109951165726231133.jpg?param=1024y1024" : resultSysUserInfoDto.headPortrait;
            resultSysUserInfoDto.userShowName = string.IsNullOrWhiteSpace(resultSysUserInfoDto.userShowName) ? "admin" : resultSysUserInfoDto.userShowName;
            resultSysUserInfoDto.introduction = string.IsNullOrWhiteSpace(resultSysUserInfoDto.introduction) ? "该用户什么都没有填写..." : resultSysUserInfoDto.introduction;
            resultSysUserInfoDto.userShowName = string.IsNullOrWhiteSpace(resultSysUserInfoDto.userShowName) ? "admin" : resultSysUserInfoDto.userShowName;
            return resultSysUserInfoDto;
        }
        #endregion
    }
}
