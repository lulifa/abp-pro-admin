using Volo.Abp.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using VoloAbpAccountApplicationContractsModule = Volo.Abp.Account.AbpAccountApplicationContractsModule;

namespace RuiChen.AbpPro.Account
{
    [DependsOn(
        typeof(VoloAbpAccountApplicationContractsModule)
        )]
    public class AbpAccountApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAccountApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<AccountResource>().AddVirtualJson("/RuiChen/AbpPro/Account/Localization/Resources");
            });

        }
    }
}
