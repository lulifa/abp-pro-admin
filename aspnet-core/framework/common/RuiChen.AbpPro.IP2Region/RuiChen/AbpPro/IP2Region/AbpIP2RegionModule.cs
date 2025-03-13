using IP2Region.Net.Abstractions;
using IP2Region.Net.XDB;
using RuiChen.AbpPro.IP.Location;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.IP2Region
{

    [DependsOn(typeof(AbpIPLocationModule))]
    [DependsOn(typeof(AbpVirtualFileSystemModule))]
    public class AbpIP2RegionModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIP2RegionModule>();
            });

            context.Services.AddSingleton<ISearcher, AbpSearcher>((serviceProvider) =>
            {
                var virtualFileProvider = serviceProvider.GetRequiredService<IVirtualFileProvider>();
                var xdbFile = virtualFileProvider.GetFileInfo("/RuiChen/AbpPro/IP2Region/Resources/ip2region.xdb");
                var searcher = new AbpSearcher(CachePolicy.File, xdbFile.CreateReadStream());

                return searcher;
            });

            Configure<AbpIPLocationResolveOptions>(options =>
            {
                options.IPLocationResolvers.Add(new IP2RegionIPLocationResolveContributorBase());
            });
        }
    }

}
