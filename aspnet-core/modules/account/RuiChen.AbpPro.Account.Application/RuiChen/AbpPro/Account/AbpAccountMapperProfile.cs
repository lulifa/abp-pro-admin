using AutoMapper;
using RuiChen.AbpPro.AuditLogging;

namespace RuiChen.AbpPro.Account
{
    public class AbpAccountMapperProfile : Profile
    {
        public AbpAccountMapperProfile()
        {
            CreateMap<SecurityLog, SecurityLogDto>(MemberList.Destination);
        }
    }
}
