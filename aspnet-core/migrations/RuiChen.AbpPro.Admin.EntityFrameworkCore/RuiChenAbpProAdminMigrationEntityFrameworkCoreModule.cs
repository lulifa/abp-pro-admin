using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.AuditLogging.EntityFrameworkCore;
using RuiChen.AbpPro.Data.DbMigrator;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.Saas;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSaasEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpOpenIddictEntityFrameworkCoreModule),
        typeof(AbpDataDbMigratorModule),
        typeof(AbpEntityFrameworkCoreMySQLModule)
    )]
    public class RuiChenAbpProAdminMigrationEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<RuiChenAbpProAdminMigrationDbContext>();

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL(
                    mysql =>
                    {
                        // see: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/1960
                        mysql.TranslateParameterizedCollectionsToConstants();
                    });
            });
        }

    }
}
