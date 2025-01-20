using RuiChen.AbpPro.Account;
using RuiChen.AbpPro.FeatureManagement;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.OpenIddict;
using RuiChen.AbpPro.PermissionManagement;
using RuiChen.AbpPro.Saas;
using RuiChen.AbpPro.SettingManagement;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace RuiChen.AbpPro.Admin.HttpApi.Host
{
    [DependsOn(
        typeof(AbpAccountHttpApiModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpAccountWebOpenIddictModule),

        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),


        typeof(AbpIdentityHttpApiModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),


        typeof(AbpOpenIddictHttpApiModule),
        typeof(AbpOpenIddictApplicationModule),
        typeof(AbpOpenIddictEntityFrameworkCoreModule),


        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),


        typeof(AbpSaasHttpApiModule),
        typeof(AbpSaasApplicationModule),
        typeof(AbpSaasEntityFrameworkCoreModule),


        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),


        typeof(AbpAspNetCoreMvcUiBasicThemeModule),


        typeof(AbpCachingModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAutofacModule)
    )]
    public partial class RuiChenAbpProAdminHttpApiHostModule : AbpModule
    {

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            PreConfigureFeature();

            PreConfigureAuthServer(configuration);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var hostingEnvironment = services.GetHostingEnvironment();
            var configuration = services.GetConfiguration();

            ConfigureDbContext();

            ConfigureLocalization();

            ConfigureKestrelServer();

            ConfigureVirtualFileSystem();

            ConfigureAuthServer(configuration);

            ConfigureSwagger(services);

            ConfigureMultiTenancy(configuration);

            ConfigureCors(services, configuration);

            ConfigureSecurity(services, configuration, hostingEnvironment.IsDevelopment());

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();

            app.UseForwardedHeaders();

            app.UseCookiePolicy();

            app.UseAbpRequestLocalization();

            app.UseCorrelationId();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseDynamicClaims();

            app.UseAbpOpenIddictValidation();

            app.UseUnitOfWork();

            app.UseMultiTenancy();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "RuiChenAdmin.AbpPro.Admin API");
            });

            app.UseAuditing();

            app.UseAbpSerilogEnrichers();

            app.UseConfiguredEndpoints();

        }

    }
}
