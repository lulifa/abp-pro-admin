using Microsoft.Extensions.Options;
using static RuiChen.AbpPro.Authentication.GitHub.GitHubAuthenticationDefaults;

namespace RuiChen.AbpPro.Authentication.GitHub
{
    public class GitHubPostConfigureOptions : IPostConfigureOptions<GitHubAuthenticationOptions>
    {
        /// <inheritdoc/>
        public void PostConfigure(
            string name,
            GitHubAuthenticationOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.EnterpriseDomain))
            {
                options.AuthorizationEndpoint = CreateUrl(options.EnterpriseDomain, AuthorizationEndpointPath);
                options.TokenEndpoint = CreateUrl(options.EnterpriseDomain, TokenEndpointPath);
                options.UserEmailsEndpoint = CreateUrl(options.EnterpriseDomain, EnterpriseApiPath + UserEmailsEndpointPath);
                options.UserInformationEndpoint = CreateUrl(options.EnterpriseDomain, EnterpriseApiPath + UserInformationEndpointPath);
            }
        }

        private static string CreateUrl(string domain, string path)
        {
            // Enforce use of HTTPS
            var builder = new UriBuilder(domain)
            {
                Path = path,
                Port = -1,
                Scheme = Uri.UriSchemeHttps,
            };

            return builder.Uri.ToString();
        }
    }
}
