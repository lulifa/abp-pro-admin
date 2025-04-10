using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.OssManagement
{
    [DependsOn(
       typeof(AbpOssManagementDomainSharedModule),
       typeof(AbpDddDomainModule),
       typeof(AbpMultiTenancyModule)
    )]
    public class AbpOssManagementDomainModule : AbpModule
    {
    }
}
