using Volo.Abp.Application.Services;

namespace RuiChen.AbpPro.Saas
{
    public abstract class AbpSaasAppServiceBase : ApplicationService
    {
        protected AbpSaasAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpSaasApplicationModule);
            LocalizationResource = typeof(AbpSaasResource);
        }
    }
}
