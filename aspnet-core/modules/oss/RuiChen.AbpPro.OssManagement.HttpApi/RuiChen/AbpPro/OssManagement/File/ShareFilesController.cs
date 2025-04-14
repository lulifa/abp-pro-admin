using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;

namespace RuiChen.AbpPro.OssManagement
{
    [Area("oss-management")]
    [Route("api/files/share")]
    [RemoteService(false)]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ShareFilesController : AbpControllerBase, IShareFileAppService
    {
        private readonly IShareFileAppService _service;

        public ShareFilesController(
           IShareFileAppService service)
        {
            _service = service;

            LocalizationResource = typeof(AbpOssManagementResource);
        }

        [HttpGet]
        [Route("{url}")]
        public virtual Task<IRemoteStreamContent> GetAsync(string url)
        {
            return _service.GetAsync(url);
        }
    }
}
