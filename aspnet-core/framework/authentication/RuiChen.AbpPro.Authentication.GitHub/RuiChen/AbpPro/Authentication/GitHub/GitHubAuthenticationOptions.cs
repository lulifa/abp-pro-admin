using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using static RuiChen.AbpPro.Authentication.GitHub.GitHubAuthenticationConstants;
using System.Security.Claims;

namespace RuiChen.AbpPro.Authentication.GitHub
{
    public class GitHubAuthenticationOptions: OAuthOptions
    {
        public GitHubAuthenticationOptions()
        {
            ClaimsIssuer = GitHubAuthenticationDefaults.Issuer;
            CallbackPath = GitHubAuthenticationDefaults.CallbackPath;

            AuthorizationEndpoint = GitHubAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = GitHubAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = GitHubAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey(Claims.Name, "name");
            ClaimActions.MapJsonKey(Claims.Url, "url");
        }
    }
}
