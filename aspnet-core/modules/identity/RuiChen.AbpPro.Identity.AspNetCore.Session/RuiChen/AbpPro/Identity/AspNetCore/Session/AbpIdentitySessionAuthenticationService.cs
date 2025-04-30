using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;

namespace RuiChen.AbpPro.Identity
{
    public class AbpIdentitySessionAuthenticationService : AuthenticationService
    {
        protected IdentitySessionSignInOptions SessionSignInOptions { get; }
        protected IIdentitySessionManager IdentitySessionManager { get; }

        public AbpIdentitySessionAuthenticationService(
            IAuthenticationSchemeProvider schemes,
            IAuthenticationHandlerProvider handlers,
            IClaimsTransformation transform,
            IOptions<AuthenticationOptions> options,
            IIdentitySessionManager identitySessionManager,
            IOptions<IdentitySessionSignInOptions> sessionSignInOptions) : base(schemes, handlers, transform, options)
        {
            SessionSignInOptions = sessionSignInOptions.Value;
            IdentitySessionManager = identitySessionManager;
        }

        public override async Task SignInAsync(HttpContext context, string scheme, ClaimsPrincipal principal, AuthenticationProperties properties)
        {
            await base.SignInAsync(context, scheme, principal, properties);

            if (SessionSignInOptions.SignInSessionEnabled && SessionSignInOptions.AuthenticationSchemes.Contains(scheme))
            {
                // Save the user session.
                await IdentitySessionManager.SaveSessionAsync(principal);
            }
        }

        public override async Task SignOutAsync(HttpContext context, string scheme, AuthenticationProperties properties)
        {
            if (SessionSignInOptions.SignOutSessionEnabled && SessionSignInOptions.AuthenticationSchemes.Contains(scheme))
            {
                var sessionId = context.User?.FindSessionId();
                if (!sessionId.IsNullOrWhiteSpace())
                {
                    // Revoke the user session.
                    await IdentitySessionManager.RevokeSessionAsync(sessionId);
                }
            }
            await base.SignOutAsync(context, scheme, properties);
        }

    }
}
