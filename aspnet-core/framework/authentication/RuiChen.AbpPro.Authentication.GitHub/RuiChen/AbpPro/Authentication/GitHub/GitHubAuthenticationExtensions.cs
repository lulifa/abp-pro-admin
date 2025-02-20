using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace RuiChen.AbpPro.Authentication.GitHub;

public static class GitHubAuthenticationExtensions
{
    public static AuthenticationBuilder AddGitHub(this AuthenticationBuilder builder)
    {
        return builder.AddGitHub(GitHubAuthenticationDefaults.AuthenticationScheme, options => { });
    }

    public static AuthenticationBuilder AddGitHub(
        this AuthenticationBuilder builder,
        Action<GitHubAuthenticationOptions> configuration)
    {
        return builder.AddGitHub(GitHubAuthenticationDefaults.AuthenticationScheme, configuration);
    }

    public static AuthenticationBuilder AddGitHub(
        this AuthenticationBuilder builder,
        string scheme,
        Action<GitHubAuthenticationOptions> configuration)
    {
        return builder.AddGitHub(scheme, GitHubAuthenticationDefaults.DisplayName, configuration);
    }

    public static AuthenticationBuilder AddGitHub(
        this AuthenticationBuilder builder,
        string scheme,
        string caption,
        Action<GitHubAuthenticationOptions> configuration)
    {
        return builder.AddOAuth<GitHubAuthenticationOptions, GitHubAuthenticationHandler>(scheme, caption, configuration);
    }

}
