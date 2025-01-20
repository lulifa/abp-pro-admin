using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.FeatureManagement
{
    [Route("api/feature-management/definitions")]
    [ControllerName("FeatureDefinition")]
    public class FeatureDefinitionController : FeatureManagementControllerBase, IFeatureDefinitionAppService
    {
        private readonly IFeatureDefinitionAppService service;

        public FeatureDefinitionController(IFeatureDefinitionAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual Task<FeatureDefinitionDto> CreateAsync(FeatureDefinitionCreateDto input)
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
        public virtual Task<FeatureDefinitionDto> GetAsync(string name)
        {
            return service.GetAsync(name);
        }

        [HttpGet]
        public virtual Task<ListResultDto<FeatureDefinitionDto>> GetListAsync(FeatureDefinitionGetListInput input)
        {
            return service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{name}")]
        public virtual Task<FeatureDefinitionDto> UpdateAsync(string name, FeatureDefinitionUpdateDto input)
        {
            return service.UpdateAsync(name, input);
        }

    }
}
