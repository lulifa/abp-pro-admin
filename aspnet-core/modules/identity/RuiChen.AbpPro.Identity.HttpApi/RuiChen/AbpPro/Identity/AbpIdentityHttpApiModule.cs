using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Modularity;
using VoloAbpIdentityApplicationContractsModule = Volo.Abp.Identity.AbpIdentityApplicationContractsModule;
using VoloAbpIdentityHttpApiModule = Volo.Abp.Identity.AbpIdentityHttpApiModule;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(VoloAbpIdentityHttpApiModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpIdentityAspNetCoreModule)
        )]
    public class AbpIdentityHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(IdentityResource), typeof(AbpIdentityApplicationContractsModule).Assembly);
                options.AddAssemblyResource(typeof(IdentityResource), typeof(VoloAbpIdentityApplicationContractsModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(options =>
            {
                options.AddApplicationPartIfNotExists(typeof(AbpIdentityHttpApiModule).Assembly);
            });

        }
    }
}
