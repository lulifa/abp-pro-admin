using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Identity
{
    [DependsOn(typeof(AbpCachingModule))]
    public class AbpIdentitySessionModule : AbpModule
    {
    }
}
