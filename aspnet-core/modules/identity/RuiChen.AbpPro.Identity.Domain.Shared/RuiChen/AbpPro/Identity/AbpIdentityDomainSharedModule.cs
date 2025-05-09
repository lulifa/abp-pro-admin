﻿using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using VoloAbpIdentityDomainSharedModule = Volo.Abp.Identity.AbpIdentityDomainSharedModule;


namespace RuiChen.AbpPro.Identity
{
    [DependsOn(
        typeof(VoloAbpIdentityDomainSharedModule)
        )]
    public class AbpIdentityDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<IdentityResource>().AddVirtualJson("/RuiChen/AbpPro/Identity/Localization/Resources");
            });
        }
    }
}
