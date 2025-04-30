using RuiChen.AbpPro.IP.Location;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(AbpAspNetCoreModule),
        typeof(AbpIPLocationModule),
        typeof(AbpIdentitySessionModule)
        )]
    public class AbpIdentitySessionAspNetCoreModule : AbpModule
    {
    }
}
