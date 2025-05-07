using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RuiChen.Platform
{
    public interface ILayoutAppService :
        ICrudAppService<
            LayoutDto,
            Guid,
            GetLayoutListInput,
            LayoutCreateDto,
            LayoutUpdateDto>
    {
        Task<ListResultDto<LayoutDto>> GetAllListAsync();
    }
}
