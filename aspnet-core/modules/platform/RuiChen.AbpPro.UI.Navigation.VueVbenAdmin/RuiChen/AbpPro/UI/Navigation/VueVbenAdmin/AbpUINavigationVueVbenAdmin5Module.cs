using RuiChen.AbpPro.UI.Navigation;
using Volo.Abp.Modularity;

namespace RuiChen.Platform
{
    [DependsOn(
        typeof(AbpUINavigationModule),
        typeof(PlatformDomainModule))]
    public class AbpUINavigationVueVbenAdmin5Module : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.NavigationSeedContributors.Add<VueVbenAdmin5NavigationSeedContributor>();
            });
        }
    }
}
