using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Localization;
using Volo.Abp.Validation.Localization;
using VoloAbpPermissionManagementHttpApiModule = Volo.Abp.PermissionManagement.HttpApi.AbpPermissionManagementHttpApiModule;

namespace RuiChen.AbpPro.PermissionManagement
{
    [DependsOn(
        typeof(VoloAbpPermissionManagementHttpApiModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(options =>
            {
                options.AddApplicationPartIfNotExists(typeof(AbpPermissionManagementHttpApiModule).Assembly);
            });

            PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AbpPermissionManagementResource), typeof(AbpPermissionManagementApplicationContractsModule).Assembly);
            });

        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<AbpPermissionManagementResource>().AddBaseTypes(typeof(AbpValidationResource));
            });
        }

    }
}
