using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace RuiChen.AbpPro.OpenIddict
{
    [DependsOn(
        typeof(AbpOpenIddictDomainModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpOpenIddictApplicationContractsModule)
        )]
    public class AbpOpenIddictApplicationModule : AbpModule
    {
    }
}
