using RuiChen.AbpPro.OssManagement;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FileSystemOssContainerServiceCollectionExtensions
    {
        public static IServiceCollection AddFileSystemContainer(this IServiceCollection services)
        {
            services.AddTransient<IOssContainerFactory, FileSystemOssContainerFactory>();

            services.AddTransient<IOssObjectExpireor>(provider =>
                provider
                    .GetRequiredService<IOssContainerFactory>()
                    .Create()
                    .As<FileSystemOssContainer>());

            return services;
        }
    }
}
