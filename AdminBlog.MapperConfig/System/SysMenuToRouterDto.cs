using AdminBlog.Core;
using AdminBlog.Dtos;
using Mapster;

namespace AdminBlog.MapperConfig
{
    public class SysMenuToRouterDto : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<SysMenu, ResultRouteDto>()
                .Map(dest => dest.component, src => src.Component)
                .Map(dest => dest.meta.icon, src => src.MenuIcon)
                .Map(dest => dest.meta.title, src => src.MenuName)
                .Map(dest => dest.name, src => src.MenuName)
                .Map(dest => dest.path, src => src.MenuPath);

        }
    }
}
