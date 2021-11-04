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
using Microsoft.EntityFrameworkCore;
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
        private readonly CurrentUserService _currentUserService;
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        private readonly IRepository<SysRoleMenu> _sysRoleMenuRepository;
        private readonly IRepository<SysRole> _sysRoleRepository;


        public MenuService(IRepository<SysMenu> sysMenuRepository, CurrentUserService currentUserService, IRepository<SysUserRole> sysUserRoleRepository, IRepository<SysRoleMenu> sysRoleMenuRepository, IRepository<SysRole> sysRoleRepository)
        {
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _sysMenuRepository = sysMenuRepository;
            _currentUserService = currentUserService;
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysRoleRepository = sysRoleRepository;
        }
        #endregion

        #region 系统菜单
        /// <summary>
        /// 获取级联菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("menus")]
        public async Task<PagedList<ResultSysMenuDto>> GetMenuAsync([FromQuery] SearchSysMenuDto searchDto)
        {
            #region 根据当前菜单组值
            Expression<Func<SysMenu, bool>> expression = t => true;
            if (searchDto.menuIds != null && searchDto.menuIds.Length > 0)
                expression = expression.And(a => searchDto.menuIds.Contains(a.Id));
            #endregion
            #region 关键词进行条件查询 多条件使用空格分开
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
                if (!string.IsNullOrWhiteSpace(keys[0]))
                {
                    foreach (var item in keys)
                    {
                        if (item == keys[0])
                        {
                            expression = expression.And(x => x.MenuName.Contains(item)
                                                          || x.MenuTitle.Contains(item));
                        }
                        else
                        {
                            expression = expression.Or(x => x.MenuName.Contains(item)
                                                          || x.MenuTitle.Contains(item));
                        }
                    }
                }
            }
            #endregion

            List<SysMenu> menus = _sysMenuRepository.Where(expression).ToList();
            List<SysMenu> firstMenus = menus.Where(a => a.ParentModuleID == 0).OrderBy(a => a.SortIndex).ToList();
            List<ResultSysMenuDto> resultSysMenuDtos = await GetChildMenu(firstMenus, menus);
            int totalCount = firstMenus.Count();
            PagedList<ResultSysMenuDto> pagedList = new PagedList<ResultSysMenuDto>
            {
                TotalCount = totalCount,
                TotalPages = totalCount % searchDto.pageSize == 0 ? totalCount / searchDto.pageSize : (totalCount / searchDto.pageSize) + 1,
                Items = resultSysMenuDtos,
                PageIndex = searchDto.pageIndex,
                PageSize = searchDto.pageSize,
            };
            return pagedList;
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
                List<SysMenu> children = allMenus.Where(a => a.ParentModuleID == item.Id).OrderBy(a => a.SortIndex).ToList();
                ResultSysMenuDto sysMenuDto = item.Adapt<ResultSysMenuDto>();
                if (children.Count() > 0)
                {
                    sysMenuDto.children = await GetChildMenu(children, allMenus);
                }
                resultDtos.Add(sysMenuDto);
            }
            return resultDtos;
        }

        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("allMenus")]
        public Task<List<ResultSysMenuDto>> GetAllMenuAsync([FromQuery] string keyword)
        {
            Expression<Func<SysMenu, bool>> expression = t => true;
            #region 关键词进行条件查询 多条件使用空格分开
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string[] keys = keyword.Trim().Split(' ');
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.MenuName.Contains(item)
                                                      || x.MenuTitle.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.MenuName.Contains(item)
                                                      || x.MenuTitle.Contains(item));
                    }
                }

            }
            #endregion
            List<ResultSysMenuDto> menus = _sysMenuRepository.Where(expression).Adapt<List<ResultSysMenuDto>>();
            menus.Add(new ResultSysMenuDto()
            {
                Id = 0,
                menuName = "顶级",
                sortIndex = -1,
            });
            menus = menus.OrderBy(a => a.sortIndex).ToList();
            return Task.FromResult(menus);
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
                if (string.IsNullOrWhiteSpace(sysMenuAdd.Redirect))
                    sysMenuAdd.Redirect = "noRedirect";
                sysMenuAdd.CreatedTime = DateTime.UtcNow;
                await _sysMenuRepository.InsertNowAsync(sysMenuAdd);
            }
            else
            {
                //判断菜单 是否存在
                bool IsExist = await _sysMenuRepository.AnyAsync(a => a.Id == saveDto.Id && a.MenuCode == saveDto.MenuCode);
                if (IsExist)
                {
                    if (saveDto.Id == saveDto.ParentModuleID)
                        throw Oops.Oh("该菜单的上级菜单不可选择该菜单.");
                    //更改菜单信息
                    SysMenu sysMenuUpdate = saveDto.Adapt<SysMenu>();
                    if (string.IsNullOrWhiteSpace(sysMenuUpdate.Redirect))
                        sysMenuUpdate.Redirect = "noRedirect";
                    sysMenuUpdate.UpdatedTime = DateTime.UtcNow;
                    await _sysMenuRepository.UpdateIncludeNowAsync(sysMenuUpdate, new[] {
                        nameof(sysMenuUpdate.MenuName),
                        nameof(sysMenuUpdate.IsUse),
                        nameof(sysMenuUpdate.MenuType),
                        nameof(sysMenuUpdate.MenuIcon),
                        nameof(sysMenuUpdate.MenuTitle),
                        nameof(sysMenuUpdate.ParentModuleID),
                        nameof(sysMenuUpdate.MenuPath),
                        nameof(sysMenuUpdate.SortIndex),
                        nameof(sysMenuUpdate.Hidden),
                        nameof(sysMenuUpdate.Affix),
                        nameof(sysMenuUpdate.Component),
                        nameof(sysMenuUpdate.NoCache),
                        nameof(sysMenuUpdate.AlwaysShow),
                        nameof(sysMenuUpdate.Redirect),}, true
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
        [HttpDelete("menu")]
        public async Task<bool> DeleteMenuAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysMenuRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysMenu { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysMenu.IsDeleted), nameof(SysMenu.UpdatedTime) });

            return true;
        }

        /// <summary>
        /// 获取当前登录用户拥有的角色菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("currentUserRoleMenus")]
        public async Task<List<ResultRouteDto>> GetCurrentUserRoleMenus()
        {
            //获取当前登录用户
            SysUser sysUser = await _currentUserService.GetCurrentUserAsync();
            ////获取当前登录用户拥有的角色ID集合
            //long[] roleIds = await _sysUserRoleRepository.Where(a => a.UserID == sysUser.Id).Select(a => a.RoleID).ToArrayAsync();

            var linq = from ur in _sysUserRoleRepository.Where(a => a.UserID == sysUser.Id)
                       join role in _sysRoleRepository.AsQueryable() on ur.RoleID equals role.Id into result
                       from role in result.DefaultIfEmpty()
                       select new
                       {
                           ur.RoleID,
                           role.AdminFlag,
                       };
            //获取当前登录用户拥有的角色对应的菜单ID集合
            long[] menuIds = new long[linq.Count()];
            if (linq.Where(a => a.AdminFlag == AdminTypeEnum.Yes).Count() > 0)
            {
                menuIds = await _sysMenuRepository.Entities.Select(a => a.Id).ToArrayAsync();
            }
            else
            {
                long[] roleIds = await _sysUserRoleRepository.Where(a => a.UserID == sysUser.Id).Select(a => a.RoleID).ToArrayAsync();
                menuIds = await _sysRoleMenuRepository.Entities.Where(a => roleIds.Contains(a.RoleID)).Select(a => a.MenuID).ToArrayAsync();
            }

            //获取当前登录用户拥有的角色对应的菜单集合
            List<SysMenu> menus = await _sysMenuRepository.Entities.Where(a => menuIds.Contains(a.Id) && a.IsUse == UseTypeEnum.Active).OrderBy(a => a.SortIndex).ToListAsync();
            List<ResultRouteDto> resultLst = await GetChildMenuRoute(menus.Where(a => a.ParentModuleID == 0).ToList(), menus);
            return resultLst;
        }

        /// <summary>
        /// 递归获取子菜单
        /// </summary>
        /// <param name="childrenMenus"></param>
        /// <param name="allMenus"></param>
        /// <returns></returns>
        private async Task<List<ResultRouteDto>> GetChildMenuRoute(List<SysMenu> childrenMenus, List<SysMenu> allMenus)
        {
            List<ResultRouteDto> resultDtos = new List<ResultRouteDto>();
            foreach (var item in childrenMenus)
            {
                List<SysMenu> children = allMenus.Where(a => a.ParentModuleID == item.Id).OrderBy(a => a.SortIndex).ToList();
                ResultRouteDto sysMenuDto = item.Adapt<ResultRouteDto>();
                if (children.Count() > 0)
                {
                    sysMenuDto.children = await GetChildMenuRoute(children, allMenus);
                }
                resultDtos.Add(sysMenuDto);
            }
            return resultDtos;
        }
        #endregion
    }
}
