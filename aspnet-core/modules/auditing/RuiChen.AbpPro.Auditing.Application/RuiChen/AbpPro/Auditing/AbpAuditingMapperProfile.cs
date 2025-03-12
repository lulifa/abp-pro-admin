using AutoMapper;
using RuiChen.AbpPro.AuditLogging;
using RuiChen.AbpPro.Logging;
using Volo.Abp.ObjectExtending;

namespace RuiChen.AbpPro.Auditing
{

    public class AbpAuditingMapperProfile : Profile
    {
        public AbpAuditingMapperProfile()
        {
            CreateMap<AuditLogAction, AuditLogActionDto>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);
            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
            CreateMap<EntityChangeWithUsername, EntityChangeWithUsernameDto>();
            CreateMap<EntityChange, EntityChangeDto>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);
            CreateMap<AuditLog, AuditLogDto>()
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);

            CreateMap<SecurityLog, SecurityLogDto>(MemberList.Destination)
                .MapExtraProperties(MappingPropertyDefinitionChecks.None);

            CreateMap<LogField, LogFieldDto>();
            CreateMap<LogException, LogExceptionDto>();
            CreateMap<LogInfo, LogDto>();
        }
    }

}
