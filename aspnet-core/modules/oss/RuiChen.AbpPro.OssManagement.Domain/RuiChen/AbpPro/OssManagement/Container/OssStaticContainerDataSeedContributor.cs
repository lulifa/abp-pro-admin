using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.OssManagement
{
    public class OssStaticContainerDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly AbpOssManagementOptions _options;
        private readonly IOssContainerFactory _ossContainerFactory;
        public OssStaticContainerDataSeedContributor(
            IOptions<AbpOssManagementOptions> options,
            IOssContainerFactory ossContainerFactory)
        {
            _options = options.Value;
            _ossContainerFactory = ossContainerFactory;
        }

        public async virtual Task SeedAsync(DataSeedContext context)
        {
            var ossContainer = _ossContainerFactory.Create();

            foreach (var bucket in _options.StaticBuckets)
            {
                await ossContainer.CreateIfNotExistsAsync(bucket);
            }
        }
    }
}
