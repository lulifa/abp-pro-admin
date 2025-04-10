using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace RuiChen.AbpPro.OssManagement
{
    public interface IStaticFilesAppService : IApplicationService
    {
        Task<IRemoteStreamContent> GetAsync(GetStaticFileInput input);
    }
}
