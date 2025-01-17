using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OpenIddict
{
    [Route("api/openiddict/tokens")]
    [ControllerName("OpeniddictToken")]
    public class OpenIddictTokenController : OpenIddictControllerBase, IOpenIddictTokenAppService
    {
        private readonly IOpenIddictTokenAppService service;

        public OpenIddictTokenController(IOpenIddictTokenAppService service)
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
        public Task<OpenIddictTokenDto> GetAsync(Guid id)
        {
            return service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<OpenIddictTokenDto>> GetListAsync(OpenIddictTokenGetListInput input)
        {
            return service.GetListAsync(input);
        }
    }
}
