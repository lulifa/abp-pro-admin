using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.AuditLogging;
using RuiChen.AbpPro.AuditLogging.Location;
using RuiChen.AbpPro.IP2Region;
using RuiChen.AbpPro.Logging;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Auditing
{

    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpLoggingModule),
        typeof(AbpAuditLoggingModule),
        typeof(AbpAuditLoggingIPLocationModule),
        typeof(AbpAuditingApplicationContractsModule))]
    public class AbpAuditingApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpAuditingApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpAuditingMapperProfile>(validate: true);
            });
        }
    }

}
