using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace RuiChen.AbpPro.OssManagement
{
    public interface IShareFileAppService : IApplicationService
    {
        Task<IRemoteStreamContent> GetAsync(string url);
    }
}
