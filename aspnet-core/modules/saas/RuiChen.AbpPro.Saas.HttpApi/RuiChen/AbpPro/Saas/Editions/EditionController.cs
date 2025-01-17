using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    [RequiresGlobalFeature(typeof(EditionFeature))]
    [Route("api/saas/editions")]
    [ControllerName("SaasEdition")]
    public class EditionController : AbpSaasControllerBase, IEditionAppService
    {
        private readonly IEditionAppService editionAppService;

        public EditionController(IEditionAppService editionAppService)
        {
            this.editionAppService = editionAppService;
        }

        [HttpPost]
        public virtual Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            return editionAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return editionAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EditionDto> GetAsync(Guid id)
        {
            return editionAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EditionDto>> GetListAsync(EditionGetListInput input)
        {
            return editionAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            return editionAppService.UpdateAsync(id, input);
        }


    }
}
