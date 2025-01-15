using Volo.Abp.Application.Services;
using Volo.Abp.Json;
using Volo.Abp.OpenIddict.Localization;
using Volo.Abp.Threading;

namespace RuiChen.AbpPro.OpenIddict
{

    public abstract class OpenIddictApplicationServiceBase : ApplicationService
    {
        protected IJsonSerializer JsonSerializer => LazyServiceProvider.LazyGetRequiredService<IJsonSerializer>();

        protected ICancellationTokenProvider CancellationTokenProvider => LazyServiceProvider.LazyGetRequiredService<ICancellationTokenProvider>();

        protected OpenIddictApplicationServiceBase()
        {
            LocalizationResource = typeof(AbpOpenIddictResource);
        }

        /// <summary>
        /// 获取取消令牌 正常不需要直接显示写
        /// </summary>
        /// <returns></returns>
        protected virtual CancellationToken GetCancellationToken()
        {
            return CancellationTokenProvider.FallbackToProvider();
        }
    }

}

