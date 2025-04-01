using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.Account;
using RuiChen.AbpPro.Admin.EntityFrameworkCore;
using RuiChen.AbpPro.Auditing;
using RuiChen.AbpPro.FeatureManagement;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.OpenIddict;
using RuiChen.AbpPro.PermissionManagement;
using RuiChen.AbpPro.Saas;
using RuiChen.AbpPro.SettingManagement;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;

namespace RuiChen.AbpPro.Admin.DbMigrator
{
    [DependsOn(
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpAuditingApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpOpenIddictApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSaasApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
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
