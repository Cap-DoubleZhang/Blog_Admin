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
using Microsoft.EntityFrameworkCore;
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
    [Route("api/userRoles")]
    public class UserRolesService
    {
        #region 依赖注入
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        private readonly IRepository<SysRole> _sysRoleRepository;
        public UserRolesService(IRepository<SysUserRole> sysUserRoleRepository, IRepository<SysRole> sysRoleRepository)
        {
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysRoleRepository = sysRoleRepository;
        }
        #endregion

        #region 用户角色
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("userRoles")]
        public async Task<List<ResultUserRoleDto>> GetUserRole([FromQuery] SearchUserRoleDto saerchDto)
        {
            List<SysRole> roles = await _sysRoleRepository.AsQueryable().ToListAsync();

            List<ResultUserRoleDto> resultUserRoleDtos = roles.GroupJoin(_sysUserRoleRepository.AsQueryable(), r => r.Id, ur => ur.RoleID, (r, ur) => new { r, ur })
                .SelectMany(rur => rur.ur.DefaultIfEmpty(), (rur, ur) => new ResultUserRoleDto
                {
                    Id = rur.r.Id,
                    roleName = rur.r.RoleName,
                    promiss = rur.ur.FirstOrDefault() == null ? false : true,
                    roleDesc = rur.r.RoleDesc,
                }).ToList();

            return resultUserRoleDtos;
        }

        /// <summary>
        /// 获取当前用户角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("currentUserRoles")]
        public async Task<List<ResultUserRoleDto>> GetCurrentUserRole()
        {
            List<ResultUserRoleDto> userRoleDtos = await _sysUserRoleRepository.AsQueryable().GroupJoin(_sysRoleRepository.AsQueryable(), ur => ur.RoleID, r => r.Id, (ur, r) => new { r, ur })
                .SelectMany(urr => urr.r.DefaultIfEmpty(), (urr, r) => new ResultUserRoleDto
                {
                    Id = urr.r.FirstOrDefault().Id,
                    roleName = urr.r.FirstOrDefault().RoleName,
                    promiss = true,
                }).ToListAsync();

            return userRoleDtos;
        }

        /// <summary>
        /// 删除原用户下角色并保存新角色 列表
        /// </summary>
        /// <param name="userRoleDto"></param>
        /// <returns></returns>
        [HttpPost("userRole")]
        [UnitOfWork]
        public async Task<bool> SaveUserRole(SaveUserRoleDto userRoleDto)
        {
            await _sysUserRoleRepository.Where(a => a.UserID == userRoleDto.Id).BatchDeleteAsync();

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
