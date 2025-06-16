using RuiChen.AbpPro.Account.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace RuiChen.AbpPro.Account.Web.OAuth.Pages.Account.Components.ExternalProviders;

public class ExternalProviderViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke(ExternalLoginProviderModel model)
    {
        return View($"~/Pages/Account/Components/ExternalProviders/{model.AuthenticationScheme}/Default.cshtml", model);
    }
}
