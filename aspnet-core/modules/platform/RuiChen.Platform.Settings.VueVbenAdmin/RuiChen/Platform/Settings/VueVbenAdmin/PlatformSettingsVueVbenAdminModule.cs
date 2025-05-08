using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.Platform
{
    [DependsOn(
        typeof(PlatformDomainSharedModule),
        typeof(AbpMultiTenancyModule))]
    public class PlatformSettingsVueVbenAdminModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<PlatformSettingsVueVbenAdminModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<PlatformResource>()
                    .AddVirtualJson("/RuiChen/Platform/Settings/VueVbenAdmin/Localization/Resources");
            });
        }
    }
}
