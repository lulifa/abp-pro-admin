using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace RuiChen.AbpPro.Authentication.GitHub
{
    public partial class GitHubAuthenticationHandler : OAuthHandler<GitHubAuthenticationOptions>
    {
        public GitHubAuthenticationHandler(
        IOptionsMonitor<GitHubAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder)
        {
        }

        protected override Task InitializeHandlerAsync()
        {
            return base.InitializeHandlerAsync();
        }

        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            return base.BuildChallengeUrl(properties, redirectUri);
        }

        protected override Task<OAuthTokenResponse> ExchangeCodeAsync(OAuthCodeExchangeContext context)
        {
            return base.ExchangeCodeAsync(context);
        }

        protected override Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            return base.CreateTicketAsync(identity, properties, tokens);
        }

    }
}
