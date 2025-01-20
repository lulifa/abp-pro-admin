using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.VirtualFileSystem;
using VoloAbpSettingManagementApplicationContractsModule = Volo.Abp.SettingManagement.AbpSettingManagementApplicationContractsModule;

namespace RuiChen.AbpPro.SettingManagement
{
    [DependsOn(
        typeof(VoloAbpSettingManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpSettingManagementApplicationContractsModule)
        )]
    public class AbpSettingManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddScoped<ISettingTestAppService, SettingAppService>();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementApplicationModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<AbpSettingManagementResource>().AddVirtualJson("/RuiChen/AbpPro/SettingManagement/Localization/Resources");
            });

        }
    }
}
