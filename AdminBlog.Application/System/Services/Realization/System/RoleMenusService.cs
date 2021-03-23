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
    /// 角色菜单
    /// </summary>
    [DynamicApiController]
    [Route("/api/rolemenus")]
    public class RoleMenusService
    {
        #region 依赖注入
        private readonly IRepository<SysRoleMenu> _sysRoleMenuRepository;
        public RoleMenusService(IRepository<SysRoleMenu> sysRoleMenuRepository)
        {
            _sysRoleMenuRepository = sysRoleMenuRepository;
        }
        #endregion

        #region 角色菜单
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> GetRoleMenu()
        {
            return true;
        }

        /// <summary>
        /// 删除原角色下菜单并保存新菜单列表
        /// </summary>
        /// <param name="roleMenuDto"></param>
        /// <returns></returns>
        [HttpPost("rolemenu")]
        [UnitOfWork]
        public async Task<bool> SaveRoleMenu(SaveRoleMenuDto roleMenuDto)
        {
            List<SysRoleMenu> roleMenusDelete = _sysRoleMenuRepository.Where(a => a.RoleID == roleMenuDto.Id).ToList();
            roleMenusDelete.ForEach(a =>
            {
                a.IsDeleted = true;
            });
            await _sysRoleMenuRepository.Context.BulkUpdateAsync(roleMenusDelete);
            List<SysRoleMenu> roleMenusAddList = new List<SysRoleMenu>();
            foreach (var item in roleMenuDto.menuIds)
            {
                roleMenusAddList.Add(new SysRoleMenu
                {
                    RoleID = roleMenuDto.Id,
                    MenuID = item,
                });
            }
            await _sysRoleMenuRepository.Context.BulkInsertAsync(roleMenusAddList);
            return true;
        }
        #endregion
    }
}
