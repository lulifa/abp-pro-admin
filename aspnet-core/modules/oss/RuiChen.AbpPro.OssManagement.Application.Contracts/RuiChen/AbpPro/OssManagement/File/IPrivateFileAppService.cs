using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OssManagement
{
    public interface IPrivateFileAppService : IFileAppService
    {
        Task<FileShareDto> ShareAsync(FileShareInput input);

        Task<ListResultDto<MyFileShareDto>> GetShareListAsync();
    }
}
