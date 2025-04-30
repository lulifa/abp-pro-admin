using Microsoft.Extensions.DependencyInjection;
using RuiChen.AbpPro.Identity;
using RuiChen.AbpPro.Openiddict;
using Volo.Abp.Modularity;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace RuiChen.AbpPro.OpenIddict
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentitySessionAspNetCoreModule)
    )]
    public class AbpOpenIddictAspNetCoreSessionModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<OpenIddictServerBuilder>(builder =>
            {
                builder.AddEventHandler(ProcessSignOutIdentitySession.Descriptor);
                builder.AddEventHandler(ProcessSignInIdentitySession.Descriptor);
                builder.AddEventHandler(RevocationIdentitySession.Descriptor);
                builder.AddEventHandler(UserInfoIdentitySession.Descriptor);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<IdentitySessionSignInOptions>(options =>
            {
                options.SignInSessionEnabled = true;
                options.SignOutSessionEnabled = true;
            });

            Configure<AbpOpenIddictAspNetCoreSessionOptions>(options =>
            {
                options.PersistentSessionGrantTypes.Add(GrantTypes.Password);
            });
        }
    }
}
