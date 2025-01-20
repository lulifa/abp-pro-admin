using Volo.Abp.Modularity;
using VoloAbpFeatureManagementApplicationModule = Volo.Abp.FeatureManagement.AbpFeatureManagementApplicationModule;

namespace RuiChen.AbpPro.FeatureManagement
{
    [DependsOn(
        typeof(VoloAbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationContractsModule)
        )]
    public class AbpFeatureManagementApplicationModule : AbpModule
    {
    }
}
