using System.Security.Claims;
using System.Security.Principal;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;

namespace RuiChen.AbpPro.Identity
{
    public class AbpIdentitySessionDynamicClaimsPrincipalContributor : IAbpDynamicClaimsPrincipalContributor, ITransientDependency
    {
        public async virtual Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
            var claimsIdentity = context.ClaimsPrincipal.Identities.FirstOrDefault();
            var sessionId = claimsIdentity.FindSessionId();
            var userId = claimsIdentity.FindUserId();
            if (!userId.HasValue && sessionId.IsNullOrWhiteSpace())
            {
                return;
            }
            var tenantId = claimsIdentity.FindTenantId();
            var currentTenant = context.GetRequiredService<ICurrentTenant>();
            using (currentTenant.Change(tenantId))
            {
                var identitySessionChecker = context.GetRequiredService<IIdentitySessionChecker>();
                if (!await identitySessionChecker.ValidateSessionAsync(context.ClaimsPrincipal))
                {
                    // 用户会话已过期
                    context.ClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }
        }
    }
}
