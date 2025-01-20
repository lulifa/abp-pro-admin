using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Modularity;
using VoloAbpAccountHttpApiModule = Volo.Abp.Account.AbpAccountHttpApiModule;

namespace RuiChen.AbpPro.Account
{
    [DependsOn(
        typeof(VoloAbpAccountHttpApiModule),
        typeof(AbpAccountApplicationContractsModule)
        )]
    public class AbpAccountHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AccountResource), typeof(AbpAccountApplicationContractsModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAccountHttpApiModule).Assembly);
            });

        }
    }
}
