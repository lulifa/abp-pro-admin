using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Saas
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpSaasApplicationContractsModule)
        )]
    public class AbpSaasHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AbpSaasResource), typeof(AbpSaasApplicationContractsModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(options =>
            {
                options.AddApplicationPartIfNotExists(typeof(AbpSaasHttpApiModule).Assembly);
            });

        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<AbpSaasResource>().AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
