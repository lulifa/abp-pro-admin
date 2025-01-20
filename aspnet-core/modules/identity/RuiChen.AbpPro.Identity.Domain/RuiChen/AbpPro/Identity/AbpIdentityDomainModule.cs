using Volo.Abp.Modularity;
using VoloAbpIdentityDomainModule = Volo.Abp.Identity.AbpIdentityDomainModule;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule),
        typeof(VoloAbpIdentityDomainModule)
        )]
    public class AbpIdentityDomainModule : AbpModule
    {
    }
}
