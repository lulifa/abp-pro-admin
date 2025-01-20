using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.PermissionManagement
{
    [Route("api/permission-management/definitions")]
    [ControllerName("PermissionDefinition")]
    public class PermissionDefinitionController : PermissionManagementControllerBase, IPermissionDefinitionAppService
    {
        private readonly IPermissionDefinitionAppService service;

        public PermissionDefinitionController(IPermissionDefinitionAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual Task<PermissionDefinitionDto> CreateAsync(PermissionDefinitionCreateDto input)
        {
            return service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{name}")]
        public virtual Task DeleteAsync(string name)
        {
            return service.DeleteAsync(name);
        }

        [HttpGet]
        [Route("{name}")]
        public virtual Task<PermissionDefinitionDto> GetAsync(string name)
        {
            return service.GetAsync(name);
        }

        [HttpGet]
        public virtual Task<ListResultDto<PermissionDefinitionDto>> GetListAsync(PermissionDefinitionGetListInput input)
        {
            return service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{name}")]
        public virtual Task<PermissionDefinitionDto> UpdateAsync(string name, PermissionDefinitionUpdateDto input)
        {
            return service.UpdateAsync(name, input);
        }

    }
}
