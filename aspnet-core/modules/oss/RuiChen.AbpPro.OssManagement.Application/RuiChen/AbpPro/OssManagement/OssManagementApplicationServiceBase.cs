using Volo.Abp.Application.Services;

namespace RuiChen.AbpPro.OssManagement
{
    public abstract class OssManagementApplicationServiceBase : ApplicationService
    {
        protected OssManagementApplicationServiceBase()
        {
            LocalizationResource = typeof(AbpOssManagementResource);
            ObjectMapperContext = typeof(AbpOssManagementApplicationModule);
        }
    }
}
