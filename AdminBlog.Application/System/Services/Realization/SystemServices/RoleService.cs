using AdminBlog.Common;
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
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [DynamicApiController]
    [Route("/api/[controller]")]
    public class RoleService
    {
        #region 依赖注入
        private readonly IRepository<SysRole> _sysRoleRepository;
        private readonly CurrentUserService _currentUserService;
        public RoleService(IRepository<SysRole> sysRoleRepository, CurrentUserService currentUserService)
        {
            _sysRoleRepository = sysRoleRepository;
            _currentUserService = currentUserService;
        }
        #endregion

        #region 系统角色
        /// <summary>
        /// 获取系统角色分页列表
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [HttpGet("roles")]
        public async Task<PagedList<ResultSysRoleDto>> GetPagedSysRolesAsync([FromQuery] SearchSysRoleDto searchDto)
        {
            #region 关键词进行条件查询 多条件使用空格分开
            Expression<Func<SysRole, bool>> expression = t => true;
            if (!string.IsNullOrWhiteSpace(searchDto.keyword))
            {
                string[] keys = searchDto.keyword.Trim().Split(' ');
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
            }
            #endregion

            expression = expression.AndIf(searchDto.adminFlag != -1, a => a.AdminFlag == (AdminTypeEnum)searchDto.adminFlag);
            expression = expression.AndIf(searchDto.isUse != -1, a => a.IsUse == (UseTypeEnum)searchDto.isUse);

            PagedList<SysRole> sysRolesPaged = await _sysRoleRepository.Where(expression).OrderByDescending(a => a.CreatedTime).ToPagedListAsync(searchDto.pageIndex, searchDto.pageSize);

            return sysRolesPaged.Adapt<PagedList<ResultSysRoleDto>>();
        }

        /// <summary>
        /// 新增/编辑 角色信息
        /// </summary>
        /// <param name="saveDto"></param>
        /// <returns></returns>
        [HttpPost("role")]
        public async Task<bool> SaveSysRoleAsync(SaveSysRoleDto saveDto)
        {
            if (saveDto.Id == 0)
            {
                //判断角色是否存在
                bool IsExist = await _sysRoleRepository.AnyAsync(a => a.RoleName == saveDto.RoleName);
                if (IsExist)
                    throw Oops.Oh(RoleErrorCodeEnum.RoleNameExist);
                //新增角色信息
                SysRole sysRoleAdd = saveDto.Adapt<SysRole>();
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
                    await _sysRoleRepository.UpdateIncludeExistsNowAsync(sysRoleUpdate, new[] { nameof(sysRoleUpdate.RoleDesc), nameof(sysRoleUpdate.AdminFlag) }, true
                        );
                }
                else
                {
                    throw Oops.Oh(RoleErrorCodeEnum.RoleNonExist);
                }
            }
            return true;
        }

        /// <summary>
        /// 更新单个/批量角色是否可用
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut("roleIsUse")]
        public async Task<bool> UpdateRoleIsUseAsync(UpdateSysRoleUseDto updateDto)
        {
            await _sysRoleRepository.Where(a => updateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysRole { IsUse = updateDto.IsUse }, new List<string> { nameof(SysRole.IsUse) });
            return true;
        }

        /// <summary>
        /// 更新单个/批量角色是否为管理员
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut("roleAdminFlag")]
        public async Task<bool> UpdateRoleIsAdminAsync(UpdateSysRoleAdminDto updateDto)
        {
            await _sysRoleRepository.Where(a => updateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysRole { AdminFlag = updateDto.adminFlag }, new List<string> { nameof(SysRole.AdminFlag) });
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
            await _sysRoleRepository.Where(a => baseBatchUpdateDto.ids.Contains(a.Id)).BatchUpdateAsync(new SysRole { IsDeleted = true }, new List<string> { nameof(SysRole.IsDeleted) });

            return true;
        }
        #endregion
    }
}
