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
using Yitter.IdGenerator;

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
        private readonly IRepository<SysMenu> _sysMenuRepository;
        public RoleMenusService(IRepository<SysRoleMenu> sysRoleMenuRepository, IRepository<SysMenu> sysMenuRepository)
        {
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _sysMenuRepository = sysMenuRepository;
        }
        #endregion

        #region 角色菜单
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ResultRoleMenuDto>> GetRoleMenu(SearchRoleMenuDto searchDto)
        {
            List<SysMenu> menus = await _sysMenuRepository.Entities.OrderBy(a => a.SortIndex).ToListAsync();
            List<ResultRoleMenuDto> resultLst = new List<ResultRoleMenuDto>();
            foreach (var item in menus.Where(a => a.ParentModuleID == 0))
            {
                resultLst.AddRange(await GetRoleMenusChildren(menus, item));
            }
            return resultLst;
        }

        public async Task<List<ResultRoleMenuDto>> GetRoleMenusChildren(List<SysMenu> menus, SysMenu parent)
        {
            List<SysMenu> childrens = menus.Where(a => a.ParentModuleID == parent.Id).ToList();
            List<ResultRoleMenuDto> resultLst = new List<ResultRoleMenuDto>();
            if (childrens.Count() > 0)
            {
                foreach (var item in childrens)
                {
                    resultLst.AddRange(await GetRoleMenusChildren(menus, item));
                }
            }
            return resultLst;
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
            var roleMenusDelete = await _sysRoleMenuRepository.Where(a => a.RoleID == roleMenuDto.Id).ToListAsync();
            await _sysRoleMenuRepository.DeleteAsync(roleMenusDelete);

            var roles = roleMenuDto.menuIds.Select(a => new SysRoleMenu
            {
                Id = YitIdHelper.NextId(),
                RoleID = roleMenuDto.Id,
                MenuID = a,
            });
            await _sysRoleMenuRepository.InsertAsync(roles);
            return true;
        }
        #endregion
    }
}
