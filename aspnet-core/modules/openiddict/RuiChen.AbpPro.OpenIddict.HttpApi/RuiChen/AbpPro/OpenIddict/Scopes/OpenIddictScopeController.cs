using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OpenIddict
{
    [ControllerName("Openiddict-Scope")]
    [Route("api/openiddict/scopes")]
    public class OpenIddictScopeController : OpenIddictControllerBase, IOpenIddictScopeAppService
    {
        private readonly IOpenIddictScopeAppService service;

        public OpenIddictScopeController(IOpenIddictScopeAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public Task<OpenIddictScopeDto> CreateAsync(OpenIddictScopeCreateDto input)
        {
            return service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<OpenIddictScopeDto> UpdateAsync(Guid id, OpenIddictScopeUpdateDto input)
        {
            return service.UpdateAsync(id, input);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<OpenIddictScopeDto> GetAsync(Guid id)
        {
            return service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<OpenIddictScopeDto>> GetListAsync(OpenIddictScopeGetListInput input)
        {
            return service.GetListAsync(input);
        }
    }
}
