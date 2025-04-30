using OpenIddict.Server;
using RuiChen.AbpPro.Identity;

namespace RuiChen.AbpPro.OpenIddict
{
    public class ProcessSignOutIdentitySession : IOpenIddictServerHandler<OpenIddictServerEvents.ProcessSignOutContext>
    {
        protected ISessionInfoProvider SessionInfoProvider { get; }
        protected IIdentitySessionManager IdentitySessionManager { get; }

        public static OpenIddictServerHandlerDescriptor Descriptor { get; }
            = OpenIddictServerHandlerDescriptor.CreateBuilder<OpenIddictServerEvents.ProcessSignOutContext>()
                .AddFilter<OpenIddictServerHandlerFilters.RequireEndSessionRequest>()
                .UseScopedHandler<ProcessSignOutIdentitySession>()
                .SetOrder(OpenIddictServerHandlers.ValidateSignOutDemand.Descriptor.Order + 1_000)
                .SetType(OpenIddictServerHandlerType.Custom)
                .Build();

        public ProcessSignOutIdentitySession(
        ISessionInfoProvider sessionInfoProvider,
        IIdentitySessionManager identitySessionManager)
        {
            SessionInfoProvider = sessionInfoProvider;
            IdentitySessionManager = identitySessionManager;
        }

        public async virtual ValueTask HandleAsync(OpenIddictServerEvents.ProcessSignOutContext context)
        {
            var sessionId = SessionInfoProvider.SessionId;
            if (!sessionId.IsNullOrWhiteSpace())
            {
                await IdentitySessionManager.RevokeSessionAsync(sessionId);
            }
        }

    }
}
