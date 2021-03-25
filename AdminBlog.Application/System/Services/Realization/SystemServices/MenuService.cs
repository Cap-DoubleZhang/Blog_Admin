using AdminBlog.Core;
using AdminBlog.Core.Enum;
using AdminBlog.Dtos;
using EFCore.BulkExtensions;
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
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class MenuService
    {
        #region 依赖注入
        private readonly IRepository<SysMenu> _sysMenuRepository;
        public MenuService(IRepository<SysMenu> sysMenuRepository)
        {
            _sysMenuRepository = sysMenuRepository;
        }
        #endregion

        #region 系统菜单
        /// <summary>
        /// 获取级联菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("menus")]
        public async Task<List<ResultSysMenuDto>> GetMenuAsync(long[] menuIds)
        {
            #region 根据当前菜单组值
            Expression<Func<SysMenu, bool>> expression = t => true;
            if (menuIds.Length > 0)
                expression = expression.And(a => menuIds.Contains(a.Id));
            #endregion
            List<SysMenu> menus = _sysMenuRepository.Where(expression).ToList();
            List<SysMenu> firstMenus = menus.Where(a => a.ParentModuleID == 0).ToList();
            List<ResultSysMenuDto> resultSysMenuDtos = firstMenus.Adapt<List<ResultSysMenuDto>>();
            foreach (var item in resultSysMenuDtos)
            {
                item.childrenMens = await GetChildMenu(firstMenus, menus);
            }

            return resultSysMenuDtos;
        }

        /// <summary>
        /// 递归获取子菜单
        /// </summary>
        /// <param name="childrenMenus"></param>
        /// <param name="allMenus"></param>
        /// <returns></returns>
        private async Task<List<ResultSysMenuDto>> GetChildMenu(List<SysMenu> childrenMenus, List<SysMenu> allMenus)
        {
            List<ResultSysMenuDto> resultDtos = new List<ResultSysMenuDto>();
            foreach (var item in childrenMenus)
            {
                List<SysMenu> children = allMenus.Where(a => a.ParentModuleID == item.Id).ToList();
                if (children.Count() > 0)
                {
                    await GetChildMenu(children, allMenus);
                }
                ResultSysMenuDto sysMenuDto = item.Adapt<ResultSysMenuDto>();
                sysMenuDto.childrenMens = children.Adapt<List<ResultSysMenuDto>>();
                resultDtos.Add(sysMenuDto);
            }
            return resultDtos;
        }

        /// <summary>
        /// 新增/编辑 菜单信息
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("menu")]
        public async Task<bool> SaveSysMenuAsync(SaveSysMenuDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断菜单是否存在
                bool IsExist = await _sysMenuRepository.AnyAsync(a => a.MenuName == saveDto.MenuName || a.MenuCode == saveDto.MenuCode);
                if (IsExist)
                    throw Oops.Oh(SysMenuErrorCodeEnum.MenuNameExist);
                //新增菜单信息
                SysMenu sysMenuAdd = saveDto.Adapt<SysMenu>();
                sysMenuAdd.CreatedTime = DateTime.UtcNow;
                await _sysMenuRepository.InsertNowAsync(sysMenuAdd);
            }
            else
            {
                //判断菜单 是否存在
                bool IsExist = await _sysMenuRepository.AnyAsync(a => a.Id == saveDto.Id && a.MenuName == saveDto.MenuName && a.MenuCode == saveDto.MenuCode);
                if (IsExist)
                {
                    //更改菜单信息
                    SysMenu sysMenuUpdate = saveDto.Adapt<SysMenu>();
                    sysMenuUpdate.UpdatedTime = DateTime.UtcNow;
                    await _sysMenuRepository.UpdateIncludeExistsNowAsync(sysMenuUpdate, new[] {
                        nameof(sysMenuUpdate.MenuIcon),
                        nameof(sysMenuUpdate.MenuTitle),
                        nameof(sysMenuUpdate.ParentModuleID),
                        nameof(sysMenuUpdate.MenuPath),
                        nameof(sysMenuUpdate.SortIndex),}, true
                        );
                }
                else
                {
                    throw Oops.Oh(SysMenuErrorCodeEnum.MenuNonExist);
                }
            }
            return true;
        }
        /// <summary>
        /// 更新单个/批量菜单是否可用
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut("menuIsUse")]
        public async Task<bool> UpdateMenuIsUseAsync(UpdateSysMenuUseDto updateDto)
        {
            await _sysMenuRepository.Where(a => updateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysMenu { IsUse = updateDto.IsUse, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysMenu.IsUse), nameof(SysMenu.UpdatedTime) });
            return true;
        }

        /// <summary>
        /// 单个/批量删除菜单
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteMenuAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysMenuRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysMenu { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysMenu.IsDeleted), nameof(SysMenu.UpdatedTime) });

            return true;
        }

        #endregion
    }
}
