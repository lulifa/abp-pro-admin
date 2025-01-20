using Volo.Abp.Modularity;
using VoloAbpPermissionManagementApplicationModule = Volo.Abp.PermissionManagement.AbpPermissionManagementApplicationModule;

namespace RuiChen.AbpPro.PermissionManagement
{
    [DependsOn(
        typeof(VoloAbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementApplicationModule : AbpModule
    {
    }
}
