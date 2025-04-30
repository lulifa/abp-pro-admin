using AutoMapper;
using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public AbpIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentityClaimType, IdentityClaimTypeDto>().MapExtraProperties();

            CreateMap<IdentityUserClaim, IdentityClaimDto>();

            CreateMap<IdentityRoleClaim, IdentityClaimDto>();

            CreateMap<IdentityUser, IdentityUserDto>().MapExtraProperties();

            CreateMap<IdentitySession, IdentitySessionDto>();

            CreateMap<IdentityRole, IdentityRoleDto>().MapExtraProperties();

            CreateMap<OrganizationUnit, OrganizationUnitDto>().MapExtraProperties();
        }
    }
}
