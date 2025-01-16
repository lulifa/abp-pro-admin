using Autofac.Core;
using RuiChen.AbpPro.OpenIddict;
using RuiChen.AbpPro.Saas;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace RuiChen.AbpPro.Admin.HttpApi.Host
{
    [DependsOn(
        typeof(AbpAccountApplicationModule),
        typeof(AbpAccountWebOpenIddictModule),

        typeof(AbpOpenIddictHttpApiModule),
        typeof(AbpOpenIddictApplicationModule),
        typeof(AbpOpenIddictEntityFrameworkCoreModule),

        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),

        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),

        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),

        typeof(AbpSaasHttpApiModule),
        typeof(AbpSaasApplicationModule),
        typeof(AbpSaasEntityFrameworkCoreModule),

        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),

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
