using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace RuiChen.AbpPro.Authentication.Gitee
{
    public static class GiteeAuthenticationExtensions
    {
        public static AuthenticationBuilder AddGitee(this AuthenticationBuilder builder)
        {
            return builder.AddGitee(GiteeAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        public static AuthenticationBuilder AddGitee(
             this AuthenticationBuilder builder,
             Action<GiteeAuthenticationOptions> configuration)
        {
            return builder.AddGitee(GiteeAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        public static AuthenticationBuilder AddGitee(
             this AuthenticationBuilder builder,
             string scheme,
             Action<GiteeAuthenticationOptions> configuration)
        {
            return builder.AddGitee(scheme, GiteeAuthenticationDefaults.DisplayName, configuration);
        }

        public static AuthenticationBuilder AddGitee(
            this AuthenticationBuilder builder,
            string scheme,
            string caption,
            Action<GiteeAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<GiteeAuthenticationOptions, GiteeAuthenticationHandler>(scheme, caption, configuration);
        }
    }

}
