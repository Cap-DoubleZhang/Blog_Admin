using AdminBlog.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Dtos
{
    public class SaveSysMenuDto : BaseSaveDto
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空.")]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单Code
        /// </summary>
        [Required(ErrorMessage = "菜单标识不能为空.")]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string MenuTitle { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        [Required(ErrorMessage = "父级菜单不能为空.")]
        public long ParentModuleID { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        [Required(ErrorMessage = "菜单路径不能为空.")]
        public string MenuPath { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public UseTypeEnum IsUse { get; set; }

        /// <summary>
        /// 菜单类型（按钮/页面）
        /// </summary>
        public MenuTypeEnum MenuType { get; set; }
    }
}
