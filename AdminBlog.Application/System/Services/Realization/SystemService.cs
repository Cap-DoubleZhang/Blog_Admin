using AdminBlog.Common;
using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using EFCore.BulkExtensions;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
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

namespace AdminBlog.Application
{
    [DynamicApiController]
    public class SystemService
    {
        #region 依赖注入
        private readonly IRepository<SysUser> _sysUserRepository;
        private readonly IRepository<SysUserInfo> _sysUserInfoRepository;
        private readonly IRepository<SysRole> _sysRoleRepository;
        public SystemService(IRepository<SysUser> sysUserRepository, IRepository<SysUserInfo> sysUserInfoRepository, IRepository<SysRole> sysRoleRepository)
        {
            _sysUserRepository = sysUserRepository;
            _sysUserInfoRepository = sysUserInfoRepository;
            _sysRoleRepository = sysRoleRepository;
        }
        #endregion

        #region 系统用户
        /// <summary>
        /// 获取系统用户分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultSysUserDto>> GetPagedSysUsersAsync([FromQuery] SearchSysUserDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<SysUser, bool>> expression = t => true;
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
            #endregion
            PagedList<SysUser> sysUsers = await _sysUserRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return sysUsers.Adapt<PagedList<ResultSysUserDto>>();
        }

        /// <summary>
        /// 新增或更改系统用户
        /// </summary>
        /// <param name="sysUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitOfWork]
        public async Task<bool> SaveSysUserAsync(SaveSysUserDto sysUserDto)
        {
            if (sysUserDto.Id == 0)
            {
                //判断用户是否存在
                bool IsExist = await _sysUserRepository.AnyAsync(a => a.UserLoginName == sysUserDto.UserLoginName);
                if (IsExist)
                    throw Oops.Oh("该用户名已存在.");
                //新增用户登录信息
                SysUser sysUser = sysUserDto.Adapt<SysUser>();
                sysUser.UserPassword = EncryptHelper.DefaultPassword();
                sysUser.CreatedTime = DateTime.UtcNow;
                var userAdd = await _sysUserRepository.InsertNowAsync(sysUser);
                //新增用户详情
                SysUserInfo sysUserInfo = sysUserDto.Adapt<SysUserInfo>();
                sysUserInfo.UserID = userAdd.Entity.Id;
                sysUserInfo.CreatedTime = DateTime.UtcNow;
                await _sysUserInfoRepository.InsertNowAsync(sysUserInfo);
            }
            else
            {
                //判断用户是否存在
                bool IsExist = await _sysUserRepository.AnyAsync(a => a.Id == sysUserDto.Id && a.UserLoginName == sysUserDto.UserLoginName);
                if (IsExist)
                {
                    //更改用户登录信息
                    SysUser sysUser = sysUserDto.Adapt<SysUser>();
                    sysUser.UpdatedTime = DateTime.UtcNow;
                    await _sysUserRepository.UpdateIncludeExistsNowAsync(sysUser, new[] { nameof(sysUser.Descripts) }, true
                        );
                    //更改用户详情
                    SysUserInfo sysUserInfo = sysUserDto.Adapt<SysUserInfo>();
                    await _sysUserInfoRepository.UpdateExcludeExistsNowAsync(sysUserInfo, new[] {
                        nameof(sysUserInfo.UserID),
                        nameof(sysUserInfo.CreateBy),
                        nameof(sysUserInfo.CreatedTime),
                        nameof(sysUserInfo.IsDeleted)}, true
                        );
                }
                else
                {
                    throw Oops.Oh("该用户数据不存在或已被删除.");
                }
            }
            return true;
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateUserPasswordAsync(SaveSysUserPasswordDto saveSysUserPasswordDto)
        {
            SysUser user = await _sysUserRepository.FindAsync(saveSysUserPasswordDto.Id) ?? new SysUser();
            if (user.Id <= 0)
                throw Oops.Oh("该用户数据不存在或已被删除.");
            if (string.Compare(user.UserPassword, EncryptHelper.MD5Encode(saveSysUserPasswordDto.oldPassword)) != 0)
                throw Oops.Oh("原密码不正确.");
            if (string.Compare(EncryptHelper.MD5Encode(saveSysUserPasswordDto.newPassword), EncryptHelper.MD5Encode(saveSysUserPasswordDto.reNewPassword)) != 0)
                throw Oops.Oh("新密码与确认密码不一致.");
            user.UpdatedTime = DateTime.UtcNow;
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
        [HttpPost]
        public async Task<string> UserLoginAsync(SysUserLoginDto loginDto)
        {
            string MD5Password = EncryptHelper.MD5Encode(loginDto.UserPassword);
            SysUser userLogin = await _sysUserRepository.SingleAsync(a => a.UserPassword == MD5Password && a.UserLoginName == loginDto.UserLoginName);
            if (userLogin == null || userLogin.Id <= 0)
                throw Oops.Oh("用户名或密码不正确.");
            if (userLogin.IsUse == UseTypeEnum.NonUse)
                throw Oops.Oh("该用户已被禁用.");

            string accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "Id",userLogin.Id },
                { "UserLoginName",userLogin.UserLoginName }
            });
            return accessToken;
        }

        /// <summary>
        /// 更新单个/批量用户是否可用
        /// </summary>
        /// <param name="updateSysUserUseDto"></param>
        /// <returns></returns>
        [HttpPut]
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
            await _sysUserRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysUser { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysUser.IsDeleted), nameof(SysUser.UpdatedTime) });

            return true;
        }
        #endregion

        #region 系统角色
        #endregion
    }
}
