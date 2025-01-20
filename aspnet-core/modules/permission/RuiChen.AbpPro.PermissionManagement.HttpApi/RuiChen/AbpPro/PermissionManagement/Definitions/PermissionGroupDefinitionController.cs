using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.PermissionManagement
{
    [Route("api/permission-management/definitions/groups")]
    public class PermissionGroupDefinitionController : PermissionManagementControllerBase, IPermissionGroupDefinitionAppService
    {
        private readonly IPermissionGroupDefinitionAppService service;

        public PermissionGroupDefinitionController(IPermissionGroupDefinitionAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual Task<PermissionGroupDefinitionDto> CreateAsync(PermissionGroupDefinitionCreateDto input)
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
        public virtual Task<PermissionGroupDefinitionDto> GetAsync(string name)
        {
            return service.GetAsync(name);
        }

        [HttpGet]
        public virtual Task<ListResultDto<PermissionGroupDefinitionDto>> GetListAsync(PermissionGroupDefinitionGetListInput input)
        {
            return service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{name}")]
        public virtual Task<PermissionGroupDefinitionDto> UpdateAsync(string name, PermissionGroupDefinitionUpdateDto input)
        {
            return service.UpdateAsync(name, input);
        }

    }
}
