using RuiChen.AbpPro.Authorization;
using RuiChen.AbpPro.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace RuiChen.AbpPro.PermissionManagement
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpAuthorizationOrganizationUnitsModule)
        )]
    public class AbpPermissionManagementDomainOrganizationUnitsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<OrganizationUnitPermissionManagementProvider>();

                options.ProviderPolicies[OrganizationUnitPermissionValueProvider.ProviderName] = "AbpIdentity.OrganizationUnits.ManagePermissions";

            });
        }
    }
}
