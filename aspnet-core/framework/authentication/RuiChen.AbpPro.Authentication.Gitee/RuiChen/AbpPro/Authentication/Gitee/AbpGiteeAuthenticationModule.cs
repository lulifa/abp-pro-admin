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

                                //后续配置放到settings中 是否启用后再配置获取

                                options.ClientId = configuration["Authentication:Gitee:ClientId"];

                                options.ClientSecret = configuration["Authentication:Gitee:ClientSecret"];

                            });
        }
    }
}
