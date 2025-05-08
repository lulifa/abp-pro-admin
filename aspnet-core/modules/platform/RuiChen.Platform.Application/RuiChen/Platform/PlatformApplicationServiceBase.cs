using Volo.Abp.Application.Services;

namespace RuiChen.Platform
{
    public abstract class PlatformApplicationServiceBase : ApplicationService
    {
        protected PlatformApplicationServiceBase()
        {
            LocalizationResource = typeof(PlatformResource);
            ObjectMapperContext = typeof(PlatformApplicationModule);
        }
    }
}
