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
        [HttpGet("roleMenus")]
        public async Task<ResultRoleMenuIdsDto> GetRoleMenu([FromQuery] SearchRoleMenuDto searchDto)
        {
            List<SysMenu> menus = await _sysMenuRepository.Entities.OrderBy(a => a.SortIndex).ToListAsync();
            List<ResultRoleMenuDto> resultLst = await GetRoleMenusChildren(menus, menus.Where(a => a.ParentModuleID == 0).ToList());
            long[] menuIds = await _sysRoleMenuRepository.Entities.Where(a => a.RoleID == searchDto.roleId).Select(a => a.MenuID).ToArrayAsync();
            ResultRoleMenuIdsDto dto = new ResultRoleMenuIdsDto
            {
                menuIds = menuIds,
                ResultRoleMenuDtos = resultLst,
            };
            return dto;
        }

        /// <summary>
        /// 递归获取子列表
        /// </summary>
        /// <param name="menus">所有菜单</param>
        /// <param name="parentMenus">父级菜单集合</param>
        /// <returns></returns>
        private async Task<List<ResultRoleMenuDto>> GetRoleMenusChildren(List<SysMenu> menus, List<SysMenu> parentMenus)
        {
            List<ResultRoleMenuDto> resultLst = new List<ResultRoleMenuDto>();
            foreach (var item in parentMenus)
            {
                List<SysMenu> childrens = menus.Where(a => a.ParentModuleID == item.Id).OrderBy(a => a.SortIndex).ToList();
                if (childrens.Count() > 0)
                {
                    await GetRoleMenusChildren(menus, childrens);
                }
                ResultRoleMenuDto sysMenuDto = item.Adapt<ResultRoleMenuDto>();
                sysMenuDto.children = childrens.Adapt<List<ResultRoleMenuDto>>();
                resultLst.Add(sysMenuDto);
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
        public async Task<bool> SaveRoleMenu([FromBody] SaveRoleMenuDto roleMenuDto)
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
