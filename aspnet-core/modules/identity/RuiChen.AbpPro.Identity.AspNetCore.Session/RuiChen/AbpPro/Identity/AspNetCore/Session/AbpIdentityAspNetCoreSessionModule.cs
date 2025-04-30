using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(AbpIdentityAspNetCoreModule),
        typeof(AbpIdentitySessionAspNetCoreModule),
        typeof(AbpIdentityDomainModule))]
    public class AbpIdentityAspNetCoreSessionModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<IAuthenticationService, AbpIdentitySessionAuthenticationService>();
        }
    }
}
