using AutoMapper;
using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    public class IdentityDomainMappingProfile : Profile
    {
        public IdentityDomainMappingProfile()
        {
            CreateMap<IdentitySession, IdentitySessionEto>();
        }

    }
}
