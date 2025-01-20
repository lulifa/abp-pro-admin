using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Identity
{
    [Route("api/identity/roles")]
    [ControllerName("IdentityRole")]
    public class IdentityRoleController : IdentityControllerBase, IIdentityRoleAppService
    {
        private readonly IIdentityRoleAppService roleAppService;

        public IdentityRoleController(IIdentityRoleAppService roleAppService)
        {
            this.roleAppService = roleAppService;
        }


        #region OrganizationUnit

        [HttpGet]
        [Route("{id}/organization-units")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync(Guid id)
        {
            return await roleAppService.GetOrganizationUnitsAsync(id);
        }

        [HttpDelete]
        [Route("{id}/organization-units/{ouId}")]
        public async virtual Task RemoveOrganizationUnitsAsync(Guid id, Guid ouId)
        {
            await roleAppService.RemoveOrganizationUnitsAsync(id, ouId);
        }

        [HttpPut]
        [Route("{id}/organization-units")]
        public async virtual Task SetOrganizationUnitsAsync(Guid id, IdentityRoleAddOrRemoveOrganizationUnitDto input)
        {
            await roleAppService.SetOrganizationUnitsAsync(id, input);
        }

        #endregion


        #region ClaimType

        [HttpPost]
        [Route("{id}/claims")]
        public async virtual Task AddClaimAsync(Guid id, IdentityRoleClaimCreateDto input)
        {
            await roleAppService.AddClaimAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}/claims")]
        public async virtual Task DeleteClaimAsync(Guid id, IdentityRoleClaimDeleteDto input)
        {
            await roleAppService.DeleteClaimAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/claims")]
        public async virtual Task UpdateClaimAsync(Guid id, IdentityRoleClaimUpdateDto input)
        {
            await roleAppService.UpdateClaimAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/claims")]
        public async virtual Task<ListResultDto<IdentityClaimDto>> GetClaimsAsync(Guid id)
        {
            return await roleAppService.GetClaimsAsync(id);
        }

        #endregion

    }
}
