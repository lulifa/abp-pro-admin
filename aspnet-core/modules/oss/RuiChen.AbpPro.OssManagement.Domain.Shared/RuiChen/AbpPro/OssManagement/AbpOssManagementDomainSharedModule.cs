using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.OssManagement
{
    [DependsOn(
    typeof(AbpFeaturesModule),
    typeof(AbpValidationModule))]
    public class AbpOssManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpOssManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpOssManagementResource>("en")
                    .AddVirtualJson("/RuiChen/AbpPro/OssManagement/Localization/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace(OssManagementErrorCodes.Namespace, typeof(AbpOssManagementResource));
            });
        }
    }
}
