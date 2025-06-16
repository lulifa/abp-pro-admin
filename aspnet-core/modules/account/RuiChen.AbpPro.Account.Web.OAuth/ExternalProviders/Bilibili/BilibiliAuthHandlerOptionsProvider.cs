using AspNet.Security.OAuth.Bilibili;
using RuiChen.AbpPro.Account.OAuth;
using Volo.Abp.Settings;

namespace RuiChen.AbpPro.Account.Web.OAuth.ExternalProviders.Bilibili;

public class BilibiliAuthHandlerOptionsProvider : OAuthHandlerOptionsProvider<BilibiliAuthenticationOptions>
{
    public BilibiliAuthHandlerOptionsProvider(ISettingProvider settingProvider) : base(settingProvider)
    {
    }

    public async override Task SetOptionsAsync(BilibiliAuthenticationOptions options)
    {
        var clientId = await SettingProvider.GetOrNullAsync(AccountOAuthSettingNames.Bilibili.ClientId);
        var clientSecret = await SettingProvider.GetOrNullAsync(AccountOAuthSettingNames.Bilibili.ClientSecret);

        if (!clientId.IsNullOrWhiteSpace())
        {
            options.ClientId = clientId;
        }
        if (!clientSecret.IsNullOrWhiteSpace())
        {
            options.ClientSecret = clientSecret;
        }
    }
}
