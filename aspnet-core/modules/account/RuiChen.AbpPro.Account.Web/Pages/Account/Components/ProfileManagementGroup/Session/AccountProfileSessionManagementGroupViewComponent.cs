using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace RuiChen.AbpPro.Account.Web.Pages.Account.Components.ProfileManagementGroup.Session;

public class AccountProfileSessionManagementGroupViewComponent : AbpViewComponent
{
    public AccountProfileSessionManagementGroupViewComponent()
    {
    }

    public async virtual Task<IViewComponentResult> InvokeAsync()
    {
        await Task.CompletedTask;

        return View("~/Pages/Account/Components/ProfileManagementGroup/Session/Index.cshtml");
    }
}
