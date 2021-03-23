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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminBlog.Application.System.Services.Realization.System
{
    /// <summary>
    /// 用户角色 
    /// </summary>
    [DynamicApiController]
    [Route("api/userroles")]
    public class UserRolesService
    {
        #region 依赖注入
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        public UserRolesService(IRepository<SysUserRole> sysUserRoleRepository)
        {
            _sysUserRoleRepository = sysUserRoleRepository;
        }
        #endregion

        #region 用户角色
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> GetUserRole()
        {
            return true;
        }

        /// <summary>
        /// 删除原用户下角色并保存新角色 列表
        /// </summary>
        /// <param name="userRoleDto"></param>
        /// <returns></returns>
        [HttpPost("userrole")]
        [UnitOfWork]
        public async Task<bool> SaveUserRole(SaveUserRoleDto userRoleDto)
        {
            List<SysUserRole> userRolesDelete = _sysUserRoleRepository.Where(a => a.RoleID == userRoleDto.Id).ToList();
            userRolesDelete.ForEach(a =>
            {
                a.IsDeleted = true;
            });
            await _sysUserRoleRepository.Context.BulkUpdateAsync(userRolesDelete);
            List<SysUserRole> userRolesAddList = new List<SysUserRole>();
            foreach (var item in userRoleDto.roleIds)
            {
                userRolesAddList.Add(new SysUserRole
                {
                    UserID = userRoleDto.Id,
                    RoleID = item,
                });
            }
            await _sysUserRoleRepository.Context.BulkInsertAsync(userRolesAddList);
            return true;
        }
        #endregion
    }
}
