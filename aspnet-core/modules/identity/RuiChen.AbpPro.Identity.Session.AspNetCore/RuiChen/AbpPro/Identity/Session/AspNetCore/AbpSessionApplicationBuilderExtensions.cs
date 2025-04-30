using Microsoft.AspNetCore.Builder;

namespace RuiChen.AbpPro.Identity
{
    public static class AbpSessionApplicationBuilderExtensions
    {
        /// <summary>
        /// 会话管理中间件
        /// 建议顺序
        /// AuthAppBuilderExtensions.UseAuthentication(IApplicationBuilder)
        /// AbpSessionApplicationBuilderExtensions.UseAbpSession(IApplicationBuilder)
        /// AbpApplicationBuilderExtensions.UseDynamicClaims(IApplicationBuilder)
        /// AuthorizationAppBuilderExtensions.UseAuthorization(IApplicationBuilder)
        public static IApplicationBuilder UseAbpSession(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AbpSessionMiddleware>();
        }

    }
}
