using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.Admin.HttpApi.Host
{
    public class TenantHeaderParameter : IOperationFilter
    {
        private readonly AbpMultiTenancyOptions multiTenancyOptions;
        private readonly AbpAspNetCoreMultiTenancyOptions aspNetCoreMultiTenancyOptions;

        public TenantHeaderParameter(IOptions<AbpMultiTenancyOptions> multiTenancyOptions,
        IOptions<AbpAspNetCoreMultiTenancyOptions> aspNetCoreMultiTenancyOptions)
        {
            this.multiTenancyOptions = multiTenancyOptions.Value;
            this.aspNetCoreMultiTenancyOptions = aspNetCoreMultiTenancyOptions.Value;
        }
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (multiTenancyOptions.IsEnabled)
            {
                operation.Parameters = operation.Parameters ?? new List<OpenApiParameter>();
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = aspNetCoreMultiTenancyOptions.TenantKey,
                    In = ParameterLocation.Header,
                    Description = "Tenant Id in http header",
                    Required = false
                });
            }
        }
    }

    public class LanguageHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = false,
                Description = "Language setting: zh-Hans or en. Default is zh-Hans.",
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
