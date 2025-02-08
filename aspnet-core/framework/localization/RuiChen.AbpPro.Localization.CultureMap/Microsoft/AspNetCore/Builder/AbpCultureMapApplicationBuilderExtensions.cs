using RuiChen.AbpPro.Localization;

namespace Microsoft.AspNetCore.Builder
{
    public static class AbpCultureMapApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMapRequestLocalization(
            this IApplicationBuilder app,
            Action<RequestLocalizationOptions> optionsAction = null)
        {
            return app.UseAbpRequestLocalization(options =>
            {
                options.RequestCultureProviders.Insert(0, new AbpCultureMapRequestCultureProvider());
                optionsAction?.Invoke(options);
            });
        }
    }
}
