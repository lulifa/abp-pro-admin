﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RuiChen.AbpPro.Account.Web.ExternalProviders;
using Volo.Abp.Account.Web;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using static Volo.Abp.Account.Web.Pages.Account.LoginModel;
using IdentityOptions = Microsoft.AspNetCore.Identity.IdentityOptions;

namespace RuiChen.AbpPro.Account.Web.OpenIddict.Pages.Account
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(
        typeof(RuiChen.AbpPro.Account.Web.Pages.Account.LoginModel),
        typeof(OpenIddictLoginModel))]
    public class OpenIddictLoginModel : RuiChen.AbpPro.Account.Web.Pages.Account.LoginModel
    {
        protected AbpOpenIddictRequestHelper OpenIddictRequestHelper { get; }
        public OpenIddictLoginModel(
            IExternalProviderService externalProviderService,
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions,
            IOptions<IdentityOptions> identityOptions,
            IdentityDynamicClaimsPrincipalContributorCache identityDynamicClaimsPrincipalContributorCache,
            AbpOpenIddictRequestHelper openIddictRequestHelper)
            : base(externalProviderService, schemeProvider, accountOptions, identityOptions, identityDynamicClaimsPrincipalContributorCache)
        {
            OpenIddictRequestHelper = openIddictRequestHelper;
        }

        public async override Task<IActionResult> OnGetAsync()
        {
            LoginInput = new LoginInputModel();

            var request = await OpenIddictRequestHelper.GetFromReturnUrlAsync(ReturnUrl);
            if (request?.ClientId != null)
            {
                // TODO: Find a proper cancel way.
                // ShowCancelButton = true;

                LoginInput.UserNameOrEmailAddress = request.LoginHint;

                //TODO: Reference AspNetCore MultiTenancy module and use options to get the tenant key!
                var tenant = request.GetParameter(TenantResolverConsts.DefaultTenantKey)?.ToString();
                if (!string.IsNullOrEmpty(tenant))
                {
                    CurrentTenant.Change(Guid.Parse(tenant));
                    Response.Cookies.Append(TenantResolverConsts.DefaultTenantKey, tenant);
                }
            }

            return await base.OnGetAsync();
        }
    }
}
