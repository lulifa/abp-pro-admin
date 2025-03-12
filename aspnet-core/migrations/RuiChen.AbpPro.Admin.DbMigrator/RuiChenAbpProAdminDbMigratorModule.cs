using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.Admin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;

namespace RuiChen.AbpPro.Admin.DbMigrator
{
    [DependsOn(
        typeof(RuiChenAbpProAdminMigrationEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class RuiChenAbpProAdminDbMigratorModule : AbpModule
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
