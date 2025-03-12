using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Logging
{
    public class AbpLoggingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<LogEnricherPropertyNames>(configuration.GetSection("Logging"));
        }

    }
}
