using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.Admin.EntityFrameworkCore;
using RuiChen.Platform;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;

namespace RuiChen.AbpPro.Admin.DbMigrator
{
    [DependsOn(
        typeof(AbpUINavigationVueVbenAdmin5Module),
        typeof(RuiChenMigrationEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class RuiChenDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpClockOptions>(options =>
            {
                configuration.GetSection("Clock").Bind(options);
            });
        }

    }
}
