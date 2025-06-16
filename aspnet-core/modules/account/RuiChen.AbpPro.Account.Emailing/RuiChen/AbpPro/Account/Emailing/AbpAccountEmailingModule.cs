using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace RuiChen.AbpPro.Account;

[DependsOn(
    typeof(AbpEmailingModule),
    typeof(AbpUiNavigationModule))]
public class AbpAccountEmailingModule:AbpModule
{

}
