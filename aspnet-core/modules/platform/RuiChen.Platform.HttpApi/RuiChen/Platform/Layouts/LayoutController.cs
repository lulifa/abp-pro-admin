using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace RuiChen.Platform
{
    [RemoteService(Name = PlatformRemoteServiceConsts.RemoteServiceName)]
    [Area("platform")]
    [Route("api/platform/layouts")]
    public class LayoutController : PlatformControllerBase, ILayoutAppService
    {
        protected ILayoutAppService LayoutAppService { get; }

        public LayoutController(
            ILayoutAppService layoutAppService)
        {
            LayoutAppService = layoutAppService;
        }

        [HttpPost]
        public async virtual Task<LayoutDto> CreateAsync(LayoutCreateDto input)
        {
            return await LayoutAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async virtual Task DeleteAsync(Guid id)
        {
            await LayoutAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async virtual Task<LayoutDto> GetAsync(Guid id)
        {
            return await LayoutAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public async virtual Task<ListResultDto<LayoutDto>> GetAllListAsync()
        {
            return await LayoutAppService.GetAllListAsync();
        }

        [HttpGet]
        public async virtual Task<PagedResultDto<LayoutDto>> GetListAsync(GetLayoutListInput input)
        {
            return await LayoutAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async virtual Task<LayoutDto> UpdateAsync(Guid id, LayoutUpdateDto input)
        {
            return await LayoutAppService.UpdateAsync(id, input);
        }
    }
}
