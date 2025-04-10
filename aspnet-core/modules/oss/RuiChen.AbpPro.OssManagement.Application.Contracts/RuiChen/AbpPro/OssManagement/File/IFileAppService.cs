using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace RuiChen.AbpPro.OssManagement
{
    public interface IFileAppService : IApplicationService
    {
        Task<OssObjectDto> UploadAsync(UploadFileInput input);

        Task<IRemoteStreamContent> GetAsync(GetPublicFileInput input);

        Task<ListResultDto<OssObjectDto>> GetListAsync(GetFilesInput input);

        Task UploadChunkAsync(UploadFileChunkInput input);

        Task DeleteAsync(GetPublicFileInput input);
    }
}
