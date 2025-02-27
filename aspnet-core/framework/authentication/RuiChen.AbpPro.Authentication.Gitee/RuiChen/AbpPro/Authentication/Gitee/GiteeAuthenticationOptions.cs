using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;
using static RuiChen.AbpPro.Authentication.Gitee.GiteeAuthenticationConstants;

namespace RuiChen.AbpPro.Authentication.Gitee
{
    public class GiteeAuthenticationOptions : OAuthOptions
    {
        public GiteeAuthenticationOptions()
        {
            ClaimsIssuer = GiteeAuthenticationDefaults.Issuer;

            CallbackPath = GiteeAuthenticationDefaults.CallbackPath;

            AuthorizationEndpoint = GiteeAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = GiteeAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = GiteeAuthenticationDefaults.UserInformationEndpoint;
            UserEmailsEndpoint = GiteeAuthenticationDefaults.UserEmailsEndpoint;

            Scope.Add("user_info");
            Scope.Add("emails");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey(Claims.Name, "name");
            ClaimActions.MapJsonKey(Claims.Url, "url");
        }

        public string UserEmailsEndpoint { get; set; }
    }
}
