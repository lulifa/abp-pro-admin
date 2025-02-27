using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Authentication.Gitee
{
    public class AbpGiteeAuthenticationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication()
                            .AddGitee(options =>
                            {
                                var configuration = context.Services.GetConfiguration();

                                options.ClientId = configuration["Authentication:Gitee:ClientId"];

                                options.ClientSecret = configuration["Authentication:Gitee:ClientSecret"];

                            });
        }
    }
}
