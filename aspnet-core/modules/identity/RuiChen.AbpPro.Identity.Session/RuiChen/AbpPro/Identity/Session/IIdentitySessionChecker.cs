using System.Security.Claims;

namespace RuiChen.AbpPro.Identity
{
    public interface IIdentitySessionChecker
    {
        Task<bool> ValidateSessionAsync(ClaimsPrincipal claimsPrincipal, CancellationToken cancellationToken = default);
    }
}
