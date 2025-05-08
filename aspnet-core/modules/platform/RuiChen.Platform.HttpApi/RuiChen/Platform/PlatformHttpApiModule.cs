using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace RuiChen.Platform
{
    [DependsOn(
        typeof(PlatformApplicationContractModule),
        typeof(PlatformThemeVueVbenAdminModule),
        typeof(AbpUINavigationVueVbenAdmin5Module),
        typeof(AbpAspNetCoreMvcModule))]
    public class PlatformHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PlatformApplicationContractModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
        }
    }
}
