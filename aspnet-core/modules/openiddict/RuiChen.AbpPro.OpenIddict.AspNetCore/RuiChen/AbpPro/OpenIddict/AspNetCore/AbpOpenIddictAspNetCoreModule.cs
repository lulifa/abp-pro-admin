using RuiChen.AbpPro.Authentication.Gitee;
using RuiChen.AbpPro.Authentication.GitHub;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.OpenIddict.AspNetCore
{
    [DependsOn(
        typeof(AbpGitHubAuthenticationModule),
        typeof(AbpGiteeAuthenticationModule)
        )]
    public class AbpOpenIddictAspNetCoreModule : AbpModule
    {
    }
}
