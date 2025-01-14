using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using OpenIddict.Server.AspNetCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;

namespace RuiChen.AbpPro.Admin.HttpApi.Host
{
    public partial class RuiChenAbpProAdminHttpApiHostModule
    {

        public static string ApplicationName = "RuiChen";

        private static readonly OneTimeRunner OneTimeRunner = new();

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

        private void ConfigureDbContext()
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));

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

        private void ConfigureVirtualFileSystem()
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<RuiChenAbpProAdminHttpApiHostModule>();
            });
        }

        private void ConfigureAuthServer(IConfiguration configuration)
        {
            Configure<OpenIddictServerAspNetCoreOptions>(options =>
            {
                options.DisableTransportSecurityRequirement = true;
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            // Swagger
            services.AddSwaggerGen(
                options =>
                {
                    // 设置 Swagger 文档的名称和版本
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin API", Version = "v1" });

                    // 文档包含谓词的过滤器，总是返回 true，意味着包含所有文档
                    options.DocInclusionPredicate((docName, description) => true);

                    // 自定义模式 ID 生成规则，使用类型的全名作为模式 ID
                    options.CustomSchemaIds(type => type.FullName);

                    var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(item => item.FullName.Contains("RuiChen")).ToArray();

                    // 遍历当前程序集中加载的所有模块
                    foreach (var assembly in assemblies)
                    {
                        // 根据程序集名称生成 XML 文件名
                        var xmlFile = $"{assembly.GetName().Name}.xml";

                        // 生成 XML 文件的完整路径
                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                        // 检查 XML 文件是否存在，存在则添加到 Swagger 配置中
                        if (File.Exists(xmlPath))
                        {
                            options.IncludeXmlComments(xmlPath, true);
                        }
                    }

                    // 定义 Bearer 认证方案
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Scheme = "bearer",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT"
                    });

                    // 添加安全要求到 Swagger 文档，要求所有请求都需要 Bearer 认证
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
                });
        }

        private void ConfigureMultiTenancy(IConfiguration configuration)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
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
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

    }
}
