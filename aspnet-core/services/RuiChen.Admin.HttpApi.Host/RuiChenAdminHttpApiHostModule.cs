﻿using RuiChen.AbpPro.Account;
using RuiChen.AbpPro.Account.Web.OpenIddict;
using RuiChen.AbpPro.Admin.EntityFrameworkCore;
using RuiChen.AbpPro.AspNetCore.HttpOverrides;
using RuiChen.AbpPro.AspNetCore.Mvc.Wrapper;
using RuiChen.AbpPro.Auditing;
using RuiChen.AbpPro.AuditLogging.EntityFrameworkCore;
using RuiChen.AbpPro.CachingManagement;
using RuiChen.AbpPro.FeatureManagement;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.Localization;
using RuiChen.AbpPro.OpenIddict;
using RuiChen.AbpPro.OssManagement;
using RuiChen.AbpPro.PermissionManagement;
using RuiChen.AbpPro.Saas;
using RuiChen.AbpPro.SettingManagement;
using RuiChen.Platform;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.VirtualFileExplorer.Web;

namespace RuiChen.Admin.HttpApi.Host
{
    [DependsOn(
        typeof(AbpAccountHttpApiModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpAccountWebOpenIddictModule),

        typeof(AbpAuditingHttpApiModule),
        typeof(AbpAuditingApplicationModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),


        typeof(AbpCachingManagementHttpApiModule),
        typeof(AbpCachingManagementApplicationModule),


        typeof(AbpPro.FeatureManagement.AbpFeatureManagementHttpApiModule),
        typeof(AbpPro.FeatureManagement.AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        // 功能管理模块 Mvc视图
        typeof(AbpFeatureManagementWebModule),


        typeof(AbpIdentityHttpApiModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        // 身份认证模块 Mvc视图
        typeof(AbpIdentityWebModule),


        typeof(AbpOpenIddictHttpApiModule),
        typeof(AbpOpenIddictApplicationModule),
        typeof(AbpOpenIddictEntityFrameworkCoreModule),


        typeof(AbpOssManagementHttpApiModule),
        typeof(AbpOssManagementApplicationModule),


        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        // 权限管理模块 Mvc视图
        typeof(AbpPermissionManagementWebModule),


        typeof(AbpSaasHttpApiModule),
        typeof(AbpSaasApplicationModule),
        typeof(AbpSaasEntityFrameworkCoreModule),


        typeof(PlatformHttpApiModule),
        typeof(PlatformApplicationModule),
        typeof(PlatformEntityFrameworkCoreModule),


        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        // 设置管理模块 Mvc视图
        typeof(AbpSettingManagementWebModule),


        typeof(AbpAspNetCoreMvcWrapperModule),
        typeof(AbpAspNetCoreHttpOverridesModule),
        typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
        typeof(RuiChenMigrationEntityFrameworkCoreModule),

        // 虚拟文件浏览器 Mvc视图
        typeof(AbpVirtualFileExplorerWebModule),
        typeof(AbpLocalizationCultureMapModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAutofacModule)
    )]
    public partial class RuiChenAdminHttpApiHostModule : AbpModule
    {

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            PreConfigureFeature();

            PreConfigureAuthServer(configuration);

            PreConfigureIdentity();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var hostingEnvironment = services.GetHostingEnvironment();
            var configuration = services.GetConfiguration();

            ConfigureWrapper();

            ConfigureClock(configuration);

            ConfigureAuditing(configuration);

            ConfigureDbContext();

            ConfigureLocalization();

            ConfigureKestrelServer();

            ConfigureOssManagement(services, configuration);

            ConfigureDistributedLock(services, configuration);

            ConfigureVirtualFileSystem();

            ConfigureAuthServer(configuration);

            ConfigureSwagger(services);

            ConfigureIdentity(configuration);

            ConfigureMvcUiTheme();

            ConfigureCaching(configuration);

            ConfigureMultiTenancy(configuration);

            ConfigureJsonSerializer(configuration);

            ConfigureFeatureManagement(configuration);

            ConfigureSettingManagement(configuration);

            ConfigurePermissionManagement(configuration);

            ConfigureCors(services, configuration);

            ConfigureSecurity(services, configuration, hostingEnvironment.IsDevelopment());

            ConfigureSingleModule(services, hostingEnvironment.IsDevelopment());

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();

            app.UseForwardedHeaders();

            app.UseAbpSecurityHeaders();

            app.UseCookiePolicy();

            app.UseMapRequestLocalization();

            app.UseCorrelationId();

            app.MapAbpStaticAssets();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAbpOpenIddictValidation();

            app.UseAbpSession();

            app.UseDynamicClaims();

            app.UseUnitOfWork();

            app.UseMultiTenancy();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "RuiChenAdmin API");
            });

            app.UseAuditing();

            app.UseAbpSerilogEnrichers();

            app.UseConfiguredEndpoints();

        }

    }
}
