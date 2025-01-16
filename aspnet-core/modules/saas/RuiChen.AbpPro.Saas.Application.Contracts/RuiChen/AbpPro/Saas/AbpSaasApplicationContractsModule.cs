using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Saas
{
    [DependsOn(
        typeof(AbpAuthorizationAbstractionsModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpSaasDomainSharedModule)
        )]
    public class AbpSaasApplicationContractsModule : AbpModule
    {
    }
}
