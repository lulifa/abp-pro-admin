using Volo.Abp.Imaging;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.OssManagement
{
    [DependsOn(
        typeof(AbpImagingAbstractionsModule),
        typeof(AbpOssManagementDomainModule))]
    public class AbpOssManagementImagingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpOssManagementOptions>(options =>
            {
                options.AddProcesser(new AbpImagingProcesserContributor());
            });
        }
    }
}
