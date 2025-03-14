using Microsoft.AspNetCore.Mvc;

namespace RuiChen.Admin.HttpApi.Host;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Redirect("/swagger");
    }
}
