using AutoMapper;
using Volo.Abp.ObjectExtending;

namespace RuiChen.AbpPro.AuditLogging.EntityFrameworkCore
{
    public class AbpAuditingMapperProfile : Profile
    {
        public AbpAuditingMapperProfile()
        {
            CreateMap<Volo.Abp.AuditLogging.AuditLogAction, AuditLogAction>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);

            CreateMap<Volo.Abp.AuditLogging.EntityPropertyChange, EntityPropertyChange>();

            CreateMap<Volo.Abp.AuditLogging.EntityChange, EntityChange>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);

            CreateMap<Volo.Abp.AuditLogging.AuditLog, AuditLog>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);

            CreateMap<Volo.Abp.AuditLogging.EntityChangeWithUsername, EntityChangeWithUsername>();

            CreateMap<Volo.Abp.Identity.IdentitySecurityLog, SecurityLog>(MemberList.Destination)
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);
        }
    }
}
