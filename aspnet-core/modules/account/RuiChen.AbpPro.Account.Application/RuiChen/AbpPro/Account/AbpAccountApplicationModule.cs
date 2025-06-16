using RuiChen.AbpPro.Account.Web.OAuth;
using RuiChen.AbpPro.Identity;
using Volo.Abp.Account.Localization;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using VoloAbpAccountApplicationModule = Volo.Abp.Account.AbpAccountApplicationModule;

namespace RuiChen.AbpPro.Account
{
    [DependsOn(
        typeof(VoloAbpAccountApplicationModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpAccountEmailingModule),
        typeof(AbpAccountWebOAuthModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpBlobStoringModule)
        )]
    public class AbpAccountApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpAccountApplicationModule>(validate: true);
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAccountApplicationModule>();
            });

            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].Urls[AccountUrlNames.EmailConfirm] = "Account/EmailConfirm";
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AccountResource>()
                    .AddBaseTypes(typeof(AccountEmailingResource));
            });
        }
    }
}
