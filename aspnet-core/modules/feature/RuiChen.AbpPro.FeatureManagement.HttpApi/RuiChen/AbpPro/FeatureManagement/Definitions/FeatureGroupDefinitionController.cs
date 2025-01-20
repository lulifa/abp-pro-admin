using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.FeatureManagement
{
    [Route("api/feature-management/definitions/groups")]
    [ControllerName("FeatureGroupDefinition")]
    public class FeatureGroupDefinitionController : FeatureManagementControllerBase, IFeatureGroupDefinitionAppService
    {
        private readonly IFeatureGroupDefinitionAppService service;

        public FeatureGroupDefinitionController(IFeatureGroupDefinitionAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual Task<FeatureGroupDefinitionDto> CreateAsync(FeatureGroupDefinitionCreateDto input)
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
        public virtual Task<FeatureGroupDefinitionDto> GetAsync(string name)
        {
            return service.GetAsync(name);
        }

        [HttpGet]
        public virtual Task<ListResultDto<FeatureGroupDefinitionDto>> GetListAsync(FeatureGroupDefinitionGetListInput input)
        {
            return service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{name}")]
        public virtual Task<FeatureGroupDefinitionDto> UpdateAsync(string name, FeatureGroupDefinitionUpdateDto input)
        {
            return service.UpdateAsync(name, input);
        }

    }
}
