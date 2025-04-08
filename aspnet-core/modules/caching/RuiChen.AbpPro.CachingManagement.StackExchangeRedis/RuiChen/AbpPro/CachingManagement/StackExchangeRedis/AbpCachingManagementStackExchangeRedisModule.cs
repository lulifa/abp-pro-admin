using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.CachingManagement
{
    [DependsOn(
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpCachingManagementDomainModule)
        )]
    public class AbpCachingManagementStackExchangeRedisModule : AbpModule
    {
    }
}
