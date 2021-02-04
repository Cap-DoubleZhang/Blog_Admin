﻿using AdminBlog.Common;
using AdminBlog.Core;
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
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    [DynamicApiController]
    public class SystemService
    {
        #region 依赖注入
        private readonly IRepository<SysUser> _sysUserRepository;
        public EncryptHelper _encryptHelper { get; set; }
        public SystemService(IRepository<SysUser> sysUserRepository, EncryptHelper encryptHelper)
        {
            _sysUserRepository = sysUserRepository;
            _encryptHelper = encryptHelper;
        }
        #endregion

        #region 系统用户
        /// <summary>
        /// 获取系统用户分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultSysUserDto>> GetSysUsersAsync([FromQuery] SearchSysUserDto searchDto)
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
                SysUser sysUser = sysUserDto.Adapt<SysUser>();
                sysUser.UserPassword = _encryptHelper.DefaultPassword();
                sysUser.CreatedTime = DateTime.UtcNow;
                var userAdd = await _sysUserRepository.InsertNowAsync(sysUser);
                SysUserInfo sysUserInfo = sysUserDto.Adapt<SysUserInfo>();
                sysUserInfo.UserID = userAdd.Entity.Id;
                sysUserInfo.CreatedTime = DateTime.UtcNow;
            }
            else
            {
                bool IsExist = await _sysUserRepository.AnyAsync(a => a.Id == sysUserDto.Id);
                if (IsExist)
                {
                    SysUser sysUser = sysUserDto.Adapt<SysUser>();
                    sysUser.UpdatedTime = DateTime.UtcNow;
                    await _sysUserRepository.UpdateIncludeExistsNowAsync(sysUser, new[] { nameof(sysUser.Descripts) }, true
                        );

                }
                else
                {
                    throw Oops.Oh("该条数据不存在或已被删除.");
                }
            }
            return true;
        }
        #endregion
    }
}
