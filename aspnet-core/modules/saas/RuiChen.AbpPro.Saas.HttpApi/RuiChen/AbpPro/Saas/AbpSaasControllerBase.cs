using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace RuiChen.AbpPro.Saas
{
    [Controller]
    [Authorize]
    [RemoteService(Name = AbpSaasRemoteServiceConsts.RemoteServiceName)]
    [Area(AbpSaasRemoteServiceConsts.ModuleName)]
    public abstract class AbpSaasControllerBase : AbpControllerBase
    {
        protected AbpSaasControllerBase()
        {
            LocalizationResource = typeof(AbpSaasResource);
        }
    }
}
