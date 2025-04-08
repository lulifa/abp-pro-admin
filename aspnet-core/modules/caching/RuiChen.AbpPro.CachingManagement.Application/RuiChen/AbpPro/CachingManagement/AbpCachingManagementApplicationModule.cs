using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.CachingManagement
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpCachingManagementApplicationContractsModule)
        )]
    public class AbpCachingManagementApplicationModule:AbpModule
    {
    }
}
