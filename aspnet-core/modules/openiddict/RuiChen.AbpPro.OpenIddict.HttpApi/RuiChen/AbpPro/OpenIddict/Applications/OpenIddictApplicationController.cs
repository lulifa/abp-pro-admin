using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OpenIddict
{
    [ControllerName("Openiddict-Application")]
    [Route("api/openiddict/applications")]
    public class OpenIddictApplicationController : OpenIddictControllerBase, IOpenIddictApplicationAppService
    {
        private readonly IOpenIddictApplicationAppService service;

        public OpenIddictApplicationController(IOpenIddictApplicationAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual Task<OpenIddictApplicationDto> CreateAsync(OpenIddictApplicationCreateDto input)
        {
            return service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<OpenIddictApplicationDto> UpdateAsync(Guid id, OpenIddictApplicationUpdateDto input)
        {
            return service.UpdateAsync(id, input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<OpenIddictApplicationDto> GetAsync(Guid id)
        {
            return service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<OpenIddictApplicationDto>> GetListAsync(OpenIddictApplicationGetListInput input)
        {
            return service.GetListAsync(input);
        }

    }
}
