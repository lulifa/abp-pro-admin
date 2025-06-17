using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.OpenApi.Models;
using OpenIddict.Server;
using OpenIddict.Server.AspNetCore;
using OpenIddict.Validation.AspNetCore;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.Localization;
using RuiChen.AbpPro.Openiddict;
using RuiChen.AbpPro.OpenIddict;
using RuiChen.AbpPro.Saas;
using RuiChen.AbpPro.Wrapper;
using RuiChen.Admin.HttpApi.Host.Bundling;
using StackExchange.Redis;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.Libs;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Caching;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement;
using Volo.Abp.Threading;
using Volo.Abp.Timing;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.Admin.HttpApi.Host
{
    public partial class RuiChenAdminHttpApiHostModule
    {

        public static string ApplicationName = "RuiChen";

        private static readonly OneTimeRunner OneTimeRunner = new();


        private void PreConfigureFeature()
        {
            OneTimeRunner.Run(() =>
            {
                GlobalFeatureManager.Instance.Modules.Saas().Editions.Enable();
            });
        }

        private void PreConfigureAuthServer(IConfiguration configuration)
        {
            PreConfigure<OpenIddictBuilder>(builder =>
            {
                builder.AddValidation(options =>
                {
                    options.AddAudiences(configuration["AuthServer:Scope"]);
                    options.UseLocalServer();
                    options.UseAspNetCore();
                });
            });
        }

        private void ConfigureWrapper()
        {
            Configure<AbpWrapperOptions>(options =>
            {
                options.IsEnabled = true;
            });
        }

        private void ConfigureClock(IConfiguration configuration)
        {
            Configure<AbpClockOptions>(options =>
            {
                configuration.GetSection("Clock").Bind(options);
            });
        }

        private void ConfigureAuditing(IConfiguration configuration)
        {
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;

                options.ApplicationName = ApplicationName;

                var allEntitiesSelectorIsEnabled = configuration["Auditing:AllEntitiesSelector"];
                if (allEntitiesSelectorIsEnabled.IsNullOrWhiteSpace() ||
                    (bool.TryParse(allEntitiesSelectorIsEnabled, out var enabled) && enabled))
                {
                    options.EntityHistorySelectors.AddAllEntities();
                }
            });
        }

        private void PreConfigureIdentity()
        {
            PreConfigure<IdentityBuilder>(builder =>
            {
                builder.AddDefaultTokenProviders();
            });
        }

        private void ConfigureDbContext()
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL(
                    mysql =>
                    {
                        // see: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/1960
                        mysql.TranslateParameterizedCollectionsToConstants();
                    });
            });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));

                var nameValues = new List<NameValue>
                {
                    new NameValue("zh_CN","zh-Hans")
                };
                var languageMap = new Dictionary<string, NameValue[]>
                {
                    { "pure-admin-ui", nameValues.ToArray() },
                    { "vben-admin-ui", nameValues.ToArray() }
                };

                foreach (var (app, mappings) in languageMap)
                {
                    options.AddLanguagesMapOrUpdate(app, mappings);
                }
                ;

            });


            Configure<AbpLocalizationCultureMapOptions>(options =>
            {
                var zhHansCultureMapInfo = new CultureMapInfo
                {
                    TargetCulture = "zh-Hans",
                    SourceCultures = ["zh-CN", "zh-HK", "zh-MO", "zh-TW"]
                };

                // 添加文化映射信息
                options.CulturesMaps.Add(zhHansCultureMapInfo);
                options.UiCulturesMaps.Add(zhHansCultureMapInfo);
            });
        }

        private void ConfigureKestrelServer()
        {
            Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = null;

                options.Limits.MaxRequestBufferSize = null;
            });
        }

        private void ConfigureOssManagement(IServiceCollection services, IConfiguration configuration)
        {
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureAll((containerName, containerConfiguration) =>
                {
                    containerConfiguration.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "blobs");
                    });
                });
            });
            services.AddFileSystemContainer();
        }

        private void ConfigureDistributedLock(IServiceCollection services, IConfiguration configuration)
        {
            var distributedLockEnabled = configuration["DistributedLock:IsEnabled"];
            if (distributedLockEnabled.IsNullOrEmpty() || bool.Parse(distributedLockEnabled))
            {
                var redis = ConnectionMultiplexer.Connect(configuration["DistributedLock:Redis:Configuration"]);
                services.AddSingleton<IDistributedLockProvider>(_ => new RedisDistributedSynchronizationProvider(redis.GetDatabase()));
            }
        }

        private void ConfigureVirtualFileSystem()
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<RuiChenAdminHttpApiHostModule>();
            });
        }

        private void ConfigureAuthServer(IConfiguration configuration)
        {
            Configure<OpenIddictServerAspNetCoreOptions>(options =>
            {
                options.DisableTransportSecurityRequirement = true;
            });

            Configure<OpenIddictServerAspNetCoreOptions>(options =>
            {
                options.DisableTransportSecurityRequirement = true;
            });

            Configure<AbpOpenIddictAspNetCoreSessionOptions>(options =>
            {

            });

            Configure<OpenIddictServerOptions>(options =>
            {

            });

        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin API", Version = "v1" });

                    options.DocInclusionPredicate((docName, description) => true);

                    options.CustomSchemaIds(type => type.FullName);

                    var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(item => item.FullName.Contains("RuiChen")).ToArray();

                    foreach (var assembly in assemblies)
                    {
                        var xmlFile = $"{assembly.GetName().Name}.xml";

                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                        if (File.Exists(xmlPath))
                        {
                            options.IncludeXmlComments(xmlPath, true);
                        }
                    }

                    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                    {
                        Description = "直接在下框输入JWT生成的Token",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            new string[] { }
                        }
                    });

                    options.OperationFilter<TenantHeaderParameter>();

                    options.OperationFilter<LanguageHeaderParameter>();

                });
        }

        private void ConfigureIdentity(IConfiguration configuration)
        {
            // 增加配置文件定义,在新建租户时需要
            Configure<IdentityOptions>(options =>
            {
                var identityConfiguration = configuration.GetSection("Identity");
                if (identityConfiguration.Exists())
                {
                    identityConfiguration.Bind(options);
                }
            });
            Configure<AbpClaimsPrincipalFactoryOptions>(options =>
            {
                options.IsDynamicClaimsEnabled = true;

                options.DynamicClaims.AddIfNotContains(AbpClaimTypes.Picture);
            });
            Configure<IdentitySessionCleanupOptions>(options =>
            {
                options.IsCleanupEnabled = true;
            });
        }

        private void ConfigureMvcUiTheme()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                //options.StyleBundles.Configure(
                //    LeptonXLiteThemeBundles.Styles.Global,
                //    bundle =>
                //    {
                //        bundle.AddFiles("/global-styles.css");
                //    }
                //);
            });

            Configure<AbpMvcLibsOptions>(options =>
            {
                options.CheckLibs = true;
            });
        }

        private void ConfigureCaching(IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                configuration.GetSection("DistributedCache").Bind(options);
            });

            Configure<RedisCacheOptions>(options =>
            {
                var redisConfig = ConfigurationOptions.Parse(options.Configuration);
                options.ConfigurationOptions = redisConfig;
                options.InstanceName = configuration["Redis:InstanceName"];
            });
        }

        private void ConfigureMultiTenancy(IConfiguration configuration)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
            });
        }

        private void ConfigureJsonSerializer(IConfiguration configuration)
        {
            // 统一时间日期格式
            Configure<AbpJsonOptions>(options =>
            {
                var jsonConfiguration = configuration.GetSection("Json");
                if (jsonConfiguration.Exists())
                {
                    jsonConfiguration.Bind(options);
                }
            });
            // 中文序列化的编码问题
            Configure<AbpSystemTextJsonSerializerOptions>(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
        }

        private void ConfigureFeatureManagement(IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("FeatureManagement:IsDynamicStoreEnabled"))
            {
                Configure<FeatureManagementOptions>(options =>
                {
                    options.IsDynamicFeatureStoreEnabled = true;
                });
            }
            Configure<FeatureManagementOptions>(options =>
            {
                options.ProviderPolicies[EditionFeatureValueProvider.ProviderName] = AbpSaasPermissions.Editions.ManageFeatures;
                options.ProviderPolicies[TenantFeatureValueProvider.ProviderName] = AbpSaasPermissions.Tenants.ManageFeatures;
            });
        }

        private void ConfigureSettingManagement(IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("SettingManagement:IsDynamicStoreEnabled"))
            {
                Configure<SettingManagementOptions>(options =>
                {
                    options.IsDynamicSettingStoreEnabled = true;
                });
            }
        }

        private void ConfigurePermissionManagement(IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("PermissionManagement:IsDynamicStoreEnabled"))
            {
                Configure<PermissionManagementOptions>(options =>
                {
                    options.IsDynamicPermissionStoreEnabled = true;
                });
            }
            Configure<PermissionManagementOptions>(options =>
            {
                // Rename IdentityServer.Client.ManagePermissions
                // See https://github.com/abpframework/abp/blob/dev/modules/identityserver/src/Volo.Abp.PermissionManagement.Domain.IdentityServer/Volo/Abp/PermissionManagement/IdentityServer/AbpPermissionManagementDomainIdentityServerModule.cs
                options.ProviderPolicies[ClientPermissionValueProvider.ProviderName] = AbpOpenIddictPermissions.Applications.ManagePermissions;
            });
        }

        private void ConfigureCors(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .WithAbpWrapExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        private void ConfigureSecurity(IServiceCollection services, IConfiguration configuration, bool isDevelopment = false)
        {
            Configure<AbpAntiForgeryOptions>(options =>
            {
                options.AutoValidate = false;
            });

            services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

            services.AddAuthentication()
                    .AddAbpJwtBearer(options =>
                    {
                        configuration.GetSection("AuthServer").Bind(options);

                        options.Events ??= new JwtBearerEvents();
                        options.Events.OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/api/files")))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        };
                    });

            //if (isDevelopment)
            //{
            //    services.AddAlwaysAllowAuthorization();
            //}

            services.AddSameSiteCookiePolicy();

        }

        private void ConfigureSingleModule(IServiceCollection services, bool isDevelopment)
        {

            Configure<AbpIdentitySessionAspNetCoreOptions>(options =>
            {
                // abp 9.0版本可存储登录IP地域, 开启IP解析
                options.IsParseIpLocation = true;
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles
                    .Configure(StandardBundles.Styles.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(SingleGlobalScriptContributor));
                    });
            });
        }

    }
}
