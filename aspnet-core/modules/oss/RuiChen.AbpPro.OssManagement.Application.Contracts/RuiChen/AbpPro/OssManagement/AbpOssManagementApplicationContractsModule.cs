using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.OssManagement
{
    [DependsOn(
          typeof(AbpOssManagementDomainSharedModule),
          typeof(AbpDddApplicationContractsModule)
      )]
    public class AbpOssManagementApplicationContractsModule : AbpModule
    {
    }
}
