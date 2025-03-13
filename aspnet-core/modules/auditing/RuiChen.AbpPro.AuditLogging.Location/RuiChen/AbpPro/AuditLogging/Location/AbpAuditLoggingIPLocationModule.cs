using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RuiChen.AbpPro.IP.Location;
using RuiChen.AbpPro.IP2Region;
using Volo.Abp.Auditing;
using Volo.Abp.Modularity;
using Volo.Abp.SecurityLog;

namespace RuiChen.AbpPro.AuditLogging.Location
{
    [DependsOn(
        typeof(AbpIPLocationModule),
        typeof(AbpIP2RegionModule),
        typeof(AbpAuditLoggingModule))]
    public class AbpAuditLoggingIPLocationModule : AbpModule
    {

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpAuditLoggingIPLocationOptions>(configuration.GetSection("AuditLogging:IPLocation"));

            context.Services.Replace(
                ServiceDescriptor.Transient<IAuditingStore, IPLocationAuditingStore>());
            context.Services.Replace(
                ServiceDescriptor.Transient<ISecurityLogStore, IPLocationSecurityLogStore>());
        }

    }
}
