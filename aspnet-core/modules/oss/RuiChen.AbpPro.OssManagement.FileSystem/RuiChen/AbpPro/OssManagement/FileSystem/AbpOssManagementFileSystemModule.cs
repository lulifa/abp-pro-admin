using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.OssManagement
{
    [DependsOn(
        typeof(AbpBlobStoringFileSystemModule),
        typeof(AbpOssManagementDomainModule))]
    public class AbpOssManagementFileSystemModule : AbpModule
    {
    }
}
