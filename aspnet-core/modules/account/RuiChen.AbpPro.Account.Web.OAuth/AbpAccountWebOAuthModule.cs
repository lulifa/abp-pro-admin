using AspNet.Security.OAuth.Bilibili;
using AspNet.Security.OAuth.GitHub;
using RuiChen.AbpPro.Account.OAuth;
using RuiChen.AbpPro.Account.Web.OAuth.ExternalProviders.Bilibili;
using RuiChen.AbpPro.Account.Web.OAuth.ExternalProviders.GitHub;
using RuiChen.AbpPro.Account.Web.OAuth.Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.Account.Web.OAuth;

[DependsOn(typeof(AbpAccountWebModule))]
[DependsOn(typeof(AbpAccountOAuthModule))]
public class AbpAccountWebOAuthModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(AccountResource), typeof(AbpAccountWebOAuthModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAccountWebOAuthModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAccountWebOAuthModule>("RuiChen.AbpPro.Account.Web.OAuth");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AccountResource>()
                .AddBaseTypes(typeof(AccountOAuthResource));
        });

        context.Services
            .AddAuthentication()
            .AddGitHub(options =>
            {
                options.ClientId = "ClientId";
                options.ClientSecret = "ClientSecret";

                options.Scope.Add("user:email");
            }).UseSettingProvider<
                GitHubAuthenticationOptions,
                GitHubAuthenticationHandler,
                GitHubAuthHandlerOptionsProvider>()
            .AddBilibili(options =>
            {
                options.ClientId = "ClientId";
                options.ClientSecret = "ClientSecret";
            }).UseSettingProvider<
                BilibiliAuthenticationOptions,
                BilibiliAuthenticationHandler,
                BilibiliAuthHandlerOptionsProvider>();
    }
}
