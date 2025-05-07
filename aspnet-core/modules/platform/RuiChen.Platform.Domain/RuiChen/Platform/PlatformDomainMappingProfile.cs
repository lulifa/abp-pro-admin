using AutoMapper;
using System.Net.Mail;

namespace RuiChen.Platform
{
    public class PlatformDomainMappingProfile:Profile
    {
        public PlatformDomainMappingProfile()
        {
            CreateMap<Layout, LayoutEto>();

            CreateMap<Menu, MenuEto>();
            CreateMap<UserMenu, UserMenuEto>();
            CreateMap<RoleMenu, RoleMenuEto>();

        }
    }
}
