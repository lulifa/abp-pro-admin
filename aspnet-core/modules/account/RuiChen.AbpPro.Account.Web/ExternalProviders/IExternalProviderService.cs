using RuiChen.AbpPro.Account.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuiChen.AbpPro.Account.Web.ExternalProviders;

public interface IExternalProviderService
{
    Task<List<ExternalLoginProviderModel>> GetAllAsync();
}
