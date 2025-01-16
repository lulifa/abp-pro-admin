using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OpenIddict
{
    [ControllerName("Openiddict-Authorization")]
    [Route("api/openiddict/authorizations")]
    public class OpenIddictAuthorizationController : OpenIddictControllerBase, IOpenIddictAuthorizationAppService
    {
        private readonly IOpenIddictAuthorizationAppService service;

        public OpenIddictAuthorizationController(IOpenIddictAuthorizationAppService service)
        {
            this.service = service;
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<OpenIddictAuthorizationDto> GetAsync(Guid id)
        {
            return service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<OpenIddictAuthorizationDto>> GetListAsync(OpenIddictAuthorizationGetListInput input)
        {
            return service.GetListAsync(input);
        }
    }
}
