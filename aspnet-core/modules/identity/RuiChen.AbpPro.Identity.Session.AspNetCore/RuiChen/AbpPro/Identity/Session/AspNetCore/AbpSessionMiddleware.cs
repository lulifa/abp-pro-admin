using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Security.Principal;
using Volo.Abp.AspNetCore.Middleware;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Tracing;

namespace RuiChen.AbpPro.Identity
{
    public class AbpSessionMiddleware : AbpMiddlewareBase, ITransientDependency
    {
        private readonly ISessionInfoProvider _sessionInfoProvider;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public AbpSessionMiddleware(
            ISessionInfoProvider sessionInfoProvider,
            ICorrelationIdProvider correlationIdProvider)
        {
            _sessionInfoProvider = sessionInfoProvider;
            _correlationIdProvider = correlationIdProvider;
        }

        public override Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var sessionId = _correlationIdProvider.Get() ?? Guid.NewGuid().ToString("N");
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var options = context.RequestServices.GetRequiredService<IOptions<AbpClaimsPrincipalFactoryOptions>>().Value;
                if (options.IsDynamicClaimsEnabled)
                {
                    // 在处理动态声明前保留全局会话用于验证
                    sessionId = context.User.FindSessionId();
                }
            }
            using (_sessionInfoProvider.Change(sessionId))
            {
                return next(context);
            }
        }
    }
}
