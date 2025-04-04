﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    [Route("api/identity/users")]
    [ControllerName("IdentityUser")]
    public class IdentityUserController : IdentityControllerBase, IIdentityUserAppService
    {
        private readonly IIdentityUserAppService userAppService;

        public IdentityUserController(IIdentityUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        #region OrganizationUnit

        [HttpGet]
        [Route("{id}/organization-units")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync(Guid id)
        {
            return await userAppService.GetOrganizationUnitsAsync(id);
        }

        [HttpDelete]
        [Route("{id}/organization-units/{ouId}")]
        public async virtual Task RemoveOrganizationUnitsAsync(Guid id, Guid ouId)
        {
            await userAppService.RemoveOrganizationUnitsAsync(id, ouId);
        }

        [HttpPut]
        [Route("{id}/organization-units")]
        public async virtual Task SetOrganizationUnitsAsync(Guid id, IdentityUserOrganizationUnitUpdateDto input)
        {
            await userAppService.SetOrganizationUnitsAsync(id, input);
        }

        #endregion

        #region ClaimType

        [HttpPost]
        [Route("{id}/claims")]
        public async virtual Task AddClaimAsync(Guid id, IdentityUserClaimCreateDto input)
        {
            await userAppService.AddClaimAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}/claims")]
        public async virtual Task DeleteClaimAsync(Guid id, IdentityUserClaimDeleteDto input)
        {
            await userAppService.DeleteClaimAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/claims")]
        public async virtual Task UpdateClaimAsync(Guid id, IdentityUserClaimUpdateDto input)
        {
            await userAppService.UpdateClaimAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/claims")]
        public async virtual Task<ListResultDto<IdentityClaimDto>> GetClaimsAsync(Guid id)
        {
            return await userAppService.GetClaimsAsync(id);
        }

        #endregion

        [HttpPut]
        [Route("change-password")]
        public async virtual Task ChangePasswordAsync(Guid id, IdentityUserSetPasswordInput input)
        {
            await userAppService.ChangePasswordAsync(id, input);
        }

        [HttpPut]
        [Route("change-two-factor")]
        public async virtual Task ChangeTwoFactorEnabledAsync(Guid id, TwoFactorEnabledDto input)
        {
            await userAppService.ChangeTwoFactorEnabledAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/lock/{seconds}")]
        public async virtual Task LockAsync(Guid id, int seconds)
        {
            await userAppService.LockAsync(id, seconds);
        }

        [HttpPut]
        [Route("{id}/unlock")]
        public async virtual Task UnLockAsync(Guid id)
        {
            await userAppService.UnLockAsync(id);
        }


        [HttpGet]
        [Route("advanced-users")]
        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUserListAdvancedAsync(GetIdentityUsersAdvancedInput input)
        {
            return await userAppService.GetUserListAdvancedAsync(input);
        }

    }
}
