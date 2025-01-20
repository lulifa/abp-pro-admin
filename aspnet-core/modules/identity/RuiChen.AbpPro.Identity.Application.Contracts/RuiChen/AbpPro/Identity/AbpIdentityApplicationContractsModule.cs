using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using VoloAbpIdentityApplicationContractsModule = Volo.Abp.Identity.AbpIdentityApplicationContractsModule;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(VoloAbpIdentityApplicationContractsModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpIdentityApplicationContractsModule : AbpModule
    {
    }
}
