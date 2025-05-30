﻿using Microsoft.Extensions.Configuration;
using OpenIddict.Abstractions;
using System.Globalization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    public class OpenIddictDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly IOpenIddictScopeManager _scopeManager;

        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTenant _currentTenant;

        public OpenIddictDataSeedContributor(
            IOpenIddictApplicationManager applicationManager,
            IOpenIddictScopeManager scopeManager,
            IPermissionDataSeeder permissionDataSeeder,
            IConfiguration configuration,
            ICurrentTenant currentTenant)
        {
            _applicationManager = applicationManager;
            _scopeManager = scopeManager;
            _permissionDataSeeder = permissionDataSeeder;
            _configuration = configuration;
            _currentTenant = currentTenant;
        }

        public async virtual Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context.TenantId))
            {
                await SeedOpenIddictAsync();
            }
        }

        #region OpenIddict

        private async Task SeedOpenIddictAsync()
        {
            var scope = _configuration["AuthServer:Scope"];

            await CreateScopeAsync(scope);
            await CreateApplicationAsync(scope);
        }

        private async Task CreateScopeAsync(string scope)
        {
            if (await _scopeManager.FindByNameAsync(scope) == null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor()
                {
                    Name = scope,
                    DisplayName = scope + " access",
                    DisplayNames =
                {
                    [CultureInfo.GetCultureInfo("zh-Hans")] = "Abp API 应用程序访问",
                    [CultureInfo.GetCultureInfo("en")] = "Abp API Application Access"
                },
                    Resources =
                {
                    scope
                }
                });
            }
        }

        private async Task CreateApplicationAsync(string scope)
        {
            var configurationSection = _configuration.GetSection("OpenIddict:Applications");

            var vueClientId = configurationSection["VueAdmin:ClientId"];
            if (!vueClientId.IsNullOrWhiteSpace())
            {
                var vueClientRootUrl = configurationSection["VueAdmin:RootUrl"].EnsureEndsWith('/');

                if (await _applicationManager.FindByClientIdAsync(vueClientId) == null)
                {
                    await _applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
                    {
                        ClientId = vueClientId,
                        ClientSecret = "1q2w3e*",
                        ApplicationType = OpenIddictConstants.ApplicationTypes.Web,
                        ConsentType = OpenIddictConstants.ConsentTypes.Explicit,
                        DisplayName = "Abp Vue Admin Client",
                        PostLogoutRedirectUris =
                    {
                        new Uri(vueClientRootUrl + "signout-callback-oidc"),
                        new Uri(vueClientRootUrl)
                    },
                        RedirectUris =
                    {
                        new Uri(vueClientRootUrl + "/signin-oidc"),
                        new Uri(vueClientRootUrl)
                    },
                        Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Authorization,
                        OpenIddictConstants.Permissions.Endpoints.Token,
                        OpenIddictConstants.Permissions.Endpoints.DeviceAuthorization,
                        OpenIddictConstants.Permissions.Endpoints.Introspection,
                        OpenIddictConstants.Permissions.Endpoints.Revocation,
                        OpenIddictConstants.Permissions.Endpoints.EndSession,

                        OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                        OpenIddictConstants.Permissions.GrantTypes.Implicit,
                        OpenIddictConstants.Permissions.GrantTypes.Password,
                        OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                        OpenIddictConstants.Permissions.GrantTypes.DeviceCode,
                        OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,

                        OpenIddictConstants.Permissions.ResponseTypes.Code,
                        OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken,
                        OpenIddictConstants.Permissions.ResponseTypes.CodeIdTokenToken,
                        OpenIddictConstants.Permissions.ResponseTypes.CodeToken,
                        OpenIddictConstants.Permissions.ResponseTypes.IdToken,
                        OpenIddictConstants.Permissions.ResponseTypes.IdTokenToken,
                        OpenIddictConstants.Permissions.ResponseTypes.None,
                        OpenIddictConstants.Permissions.ResponseTypes.Token,

                        OpenIddictConstants.Permissions.Scopes.Roles,
                        OpenIddictConstants.Permissions.Scopes.Profile,
                        OpenIddictConstants.Permissions.Scopes.Email,
                        OpenIddictConstants.Permissions.Scopes.Address,
                        OpenIddictConstants.Permissions.Scopes.Phone,
                        OpenIddictConstants.Permissions.Prefixes.Scope + scope
                    }
                    });

                    var vueClientPermissions = new string[2]
                    {
                    "AbpIdentity.UserLookup","AbpIdentity.Users"
                    };
                    await _permissionDataSeeder.SeedAsync(ClientPermissionValueProvider.ProviderName, vueClientId, vueClientPermissions);
                }
            }
        }

        #endregion
    }
}
