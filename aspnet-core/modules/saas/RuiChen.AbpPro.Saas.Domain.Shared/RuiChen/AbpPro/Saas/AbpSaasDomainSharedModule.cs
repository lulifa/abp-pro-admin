using Volo.Abp.Auditing;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.Saas
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpAuditingContractsModule)
        )]
    public class AbpSaasDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSaasDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<AbpSaasResource>().AddVirtualJson("/RuiChen/AbpPro/Saas/Localization/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace(AbpSaasErrorCodes.Namespace, typeof(AbpSaasResource));
                // 见租户管理模块
                options.MapCodeNamespace(AbpSaasErrorCodes.NamespaceMultiTenancy, typeof(AbpSaasResource));
            });

        }
    }
}
