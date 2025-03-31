using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using VoloAbpPermissionManagementApplicationModule = Volo.Abp.PermissionManagement.AbpPermissionManagementApplicationModule;

namespace RuiChen.AbpPro.PermissionManagement
{
    [DependsOn(
        typeof(VoloAbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementDomainOpenIddictModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementApplicationModule : AbpModule
    {
    }
}
