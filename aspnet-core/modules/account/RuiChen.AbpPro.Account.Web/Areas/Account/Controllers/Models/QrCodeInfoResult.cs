using RuiChen.AbpPro.Identity.QrCode;

namespace RuiChen.AbpPro.Account.Web.Areas.Account.Controllers.Models;

public class QrCodeInfoResult
{
    public string Key { get; set; }
    public QrCodeStatus Status { get; set; }
}
