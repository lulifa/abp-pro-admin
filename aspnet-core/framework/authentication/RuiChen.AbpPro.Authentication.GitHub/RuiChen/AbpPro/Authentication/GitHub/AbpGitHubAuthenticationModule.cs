using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace RuiChen.AbpPro.Authentication.GitHub
{
    public class AbpGitHubAuthenticationModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication()
                            .AddGitHub(options =>
                            {
                                var configuration = context.Services.GetConfiguration();

                                options.ClientId = configuration["Authentication:GitHub:ClientId"] ?? string.Empty;
                                options.ClientSecret = configuration["Authentication:GitHub:ClientSecret"] ?? string.Empty;
                                options.Scope.Add("user:email");
                            });
        }

    }
}
