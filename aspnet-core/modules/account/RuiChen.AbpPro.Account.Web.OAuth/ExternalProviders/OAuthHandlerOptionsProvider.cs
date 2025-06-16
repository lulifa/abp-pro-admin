using Microsoft.AspNetCore.Authentication;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace RuiChen.AbpPro.Account.Web.OAuth.ExternalProviders;

public abstract class OAuthHandlerOptionsProvider<TOptions> : IOAuthHandlerOptionsProvider<TOptions>, ITransientDependency
    where TOptions : RemoteAuthenticationOptions, new()
{
    protected ISettingProvider SettingProvider { get; }
    public OAuthHandlerOptionsProvider(ISettingProvider settingProvider)
    {
        SettingProvider = settingProvider;
    }

    public abstract Task SetOptionsAsync(TOptions options);
}
