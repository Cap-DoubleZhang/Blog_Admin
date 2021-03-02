using AdminBlog.Common;
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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
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
        private readonly IRepository<SysMenu> _sysMenuRepository;
        private readonly IRepository<SysRoleMenu> _sysRoleMenuRepository;
        private readonly IRepository<SysUserRole> _sysUserRoleRepository;
        private readonly IRepository<SysDictionary> _sysDictionaryRepository;
        public SystemService(IRepository<SysUser> sysUserRepository, IRepository<SysUserInfo> sysUserInfoRepository, IRepository<SysRole> sysRoleRepository, IRepository<SysMenu> sysMenuRepository, IRepository<SysRoleMenu> sysRoleMenuRepository, IRepository<SysUserRole> sysUserRoleRepository,
            IRepository<SysDictionary> sysDictionaryRepository)
        {
            _sysUserRepository = sysUserRepository;
            _sysUserInfoRepository = sysUserInfoRepository;
            _sysRoleRepository = sysRoleRepository;
            _sysMenuRepository = sysMenuRepository;
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysDictionaryRepository = sysDictionaryRepository;
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
            PagedList<SysUser> sysUsersPaged = await _sysUserRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return sysUsersPaged.Adapt<PagedList<ResultSysUserDto>>();
        }

        /// <summary>
        /// 根据token 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("/user/info")]
        public async Task<ResultSysUserDto> GetCurrentUserByToken([FromHeader]string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw Oops.Oh("必要参数传入为空.");
            //App.GetService
            var userId = App.User?.FindFirstValue("Id");
            SysUser user = await _sysUserRepository.FindAsync(userId) ?? new SysUser();
            return user.Adapt<ResultSysUserDto>();
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
        public async Task<string> UserLoginAsync([FromBody]SysUserLoginDto loginDto)
        {
            string MD5Password = EncryptHelper.MD5Encode(loginDto.password);
            SysUser userLogin = await _sysUserRepository.SingleAsync(a => a.UserPassword == MD5Password && a.UserLoginName == loginDto.username);
            if (userLogin == null || userLogin.Id <= 0)
                throw Oops.Oh("用户名或密码不正确.");
            if (userLogin.IsUse == UseTypeEnum.NonUse)
                throw Oops.Oh("该用户已被禁用.");

            string accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "Id",userLogin.Id },
                { "UserName",userLogin.UserLoginName },
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
        /// <summary>
        /// 获取系统角色分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultSysRoleDto>> GetPagedSysRolesAsync([FromQuery] SearchSysRoleDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<SysRole, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(keys[0]))
            {
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.RoleName.Contains(item)
                                                      || x.RoleDesc.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.RoleName.Contains(item)
                                                      || x.RoleDesc.Contains(item));
                    }
                }
            }
            #endregion

            expression = expression.AndIf(searchDto.AdminFlag != -1, a => a.AdminFlag == (AdminTypeEnum)searchDto.AdminFlag);
            expression = expression.AndIf(searchDto.IsUse != -1, a => a.IsUse == (UseTypeEnum)searchDto.IsUse);

            PagedList<SysRole> sysRolesPaged = await _sysRoleRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);

            return sysRolesPaged.Adapt<PagedList<ResultSysRoleDto>>();
        }

        /// <summary>
        /// 新增/编辑 角色信息
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> SaveSysRoleAsync(SaveSysRoleDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断角色是否存在
                bool IsExist = await _sysRoleRepository.AnyAsync(a => a.RoleName == saveDto.RoleName);
                if (IsExist)
                    throw Oops.Oh("该角色名已存在.");
                //新增角色信息
                SysRole sysRoleAdd = saveDto.Adapt<SysRole>();
                sysRoleAdd.CreatedTime = DateTime.UtcNow;
                await _sysRoleRepository.InsertNowAsync(sysRoleAdd);
            }
            else
            {
                //判断角色 是否存在
                bool IsExist = await _sysRoleRepository.AnyAsync(a => a.Id == saveDto.Id && a.RoleName == saveDto.RoleName);
                if (IsExist)
                {
                    //更改角色信息
                    SysRole sysRoleUpdate = saveDto.Adapt<SysRole>();
                    sysRoleUpdate.UpdatedTime = DateTime.UtcNow;
                    await _sysRoleRepository.UpdateIncludeExistsNowAsync(sysRoleUpdate, new[] { nameof(sysRoleUpdate.RoleDesc), nameof(sysRoleUpdate.AdminFlag) }, true
                        );
                }
                else
                {
                    throw Oops.Oh("该角色数据不存在或已被删除.");
                }
            }
            return true;
        }

        /// <summary>
        /// 更新单个/批量角色是否可用
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateRoleIsUseAsync(UpdateSysRoleUseDto updateDto)
        {
            await _sysRoleRepository.Where(a => updateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysRole { IsUse = updateDto.IsUse, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysRole.IsUse), nameof(SysRole.UpdatedTime) });
            return true;
        }

        /// <summary>
        /// 单个/批量删除角色
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteRoleAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysRoleRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysRole { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysRole.IsDeleted), nameof(SysRole.UpdatedTime) });

            return true;
        }
        #endregion

        #region 系统菜单
        /// <summary>
        /// 获取级联菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ResultSysMenuDto>> GetMenuAsync(int[] menuIds)
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
        [HttpPost]
        public async Task<bool> SaveSysMenuAsync(SaveSysMenuDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断菜单是否存在
                bool IsExist = await _sysMenuRepository.AnyAsync(a => a.MenuName == saveDto.MenuName || a.MenuCode == saveDto.MenuCode);
                if (IsExist)
                    throw Oops.Oh("该菜单名称已存在.");
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
                    throw Oops.Oh("该菜单数据不存在或已被删除.");
                }
            }
            return true;
        }
        /// <summary>
        /// 更新单个/批量菜单是否可用
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut]
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
        [HttpPost]
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
        [HttpPost]
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

        #region 系统字典
        /// <summary>
        /// 获取系统字典分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ResultDictionaryDto>> GetPagedDictionariesAsync(SearchDirctionaryDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            string[] keys = searchDto.keyword.Trim().Split(' ');
            Expression<Func<SysDictionary, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(keys[0]))
            {
                foreach (var item in keys)
                {
                    if (item == keys[0])
                    {
                        expression = expression.And(x => x.Name.Contains(item)
                                                      || x.Code.Contains(item));
                    }
                    else
                    {
                        expression = expression.Or(x => x.Name.Contains(item)
                                                      || x.Code.Contains(item));
                    }
                }
            }
            #endregion

            PagedList<SysDictionary> dictionaries = await _sysDictionaryRepository.Where(expression).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);
            return dictionaries.Adapt<PagedList<ResultDictionaryDto>>();
        }

        /// <summary>
        /// 编辑/新增 系统字典
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> SaveDictionaryAsync(SaveDictionaryDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断字典是否存在
                bool IsExist = await _sysDictionaryRepository.AnyAsync(a => a.Name == saveDto.Name && a.Code == saveDto.Code);
                if (IsExist)
                    throw Oops.Oh("该名称已存在.");
                //新增字典信息
                SysDictionary sysDictionaryAdd = saveDto.Adapt<SysDictionary>();
                sysDictionaryAdd.CreatedTime = DateTime.UtcNow;
                await _sysDictionaryRepository.InsertNowAsync(sysDictionaryAdd);
            }
            else
            {
                //判断字典 是否存在
                bool IsExist = await _sysDictionaryRepository.AnyAsync(a => a.Id == saveDto.Id && a.Name == saveDto.Name && a.Code == saveDto.Code);
                if (IsExist)
                {
                    //更改字典信息
                    SysDictionary sysDictionaryUpdate = saveDto.Adapt<SysDictionary>();
                    sysDictionaryUpdate.UpdatedTime = DateTime.UtcNow;
                    await _sysDictionaryRepository.UpdateIncludeExistsNowAsync(sysDictionaryUpdate, new[] { nameof(sysDictionaryUpdate.Value), nameof(sysDictionaryUpdate.UpdatedTime) }, true
                        );
                }
                else
                {
                    throw Oops.Oh("该字典数据不存在或已被删除.");
                }
            }
            return true;
        }

        /// <summary>
        /// 单个/批量删除角色
        /// </summary>
        /// <param name="baseBatchUpdateDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeleteDictionaryAsync(BaseBatchUpdateDto baseBatchUpdateDto)
        {
            await _sysDictionaryRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysDictionary { IsDeleted = true, UpdatedTime = DateTime.UtcNow }, new List<string> { nameof(SysDictionary.IsDeleted), nameof(SysDictionary.UpdatedTime) });

            return true;
        }
        #endregion
    }
}
