﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.CachingManagement
{
    [DependsOn(
        typeof(AbpAuthorizationModule),
        typeof(AbpDddApplicationContractsModule)
        )]
    public class AbpCachingManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpCachingManagementApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<CacheResource>().AddVirtualJson("/RuiChen/AbpPro/CachingManagement/Localization/Resources");
            });

        }
    }
}
