using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using VoloAbpIdentityEntityFrameworkCoreModule = Volo.Abp.Identity.EntityFrameworkCore.AbpIdentityEntityFrameworkCoreModule;
using VoloAbpAuditLoggingEntityFrameworkCoreModule = Volo.Abp.AuditLogging.EntityFrameworkCore.AbpAuditLoggingEntityFrameworkCoreModule;

namespace RuiChen.AbpPro.AuditLogging.EntityFrameworkCore
{
    [DependsOn(
        typeof(VoloAbpIdentityEntityFrameworkCoreModule),
        typeof(VoloAbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpAuditLoggingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpAuditLoggingEntityFrameworkCoreModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpAuditingMapperProfile>(validate: true);
            });
        }

    }
}
