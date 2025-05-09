﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Identity
{
    [Route("api/identity/claim-types")]
    [ControllerName("IdentityClaimType")]
    public class IdentityClaimTypeController : IdentityControllerBase, IIdentityClaimTypeAppService
    {
        private readonly IIdentityClaimTypeAppService identityClaimTypeAppService;

        public IdentityClaimTypeController(IIdentityClaimTypeAppService identityClaimTypeAppService)
        {
            this.identityClaimTypeAppService = identityClaimTypeAppService;
        }

        [HttpPost]
        public async virtual Task<IdentityClaimTypeDto> CreateAsync(IdentityClaimTypeCreateDto input)
        {
            return await identityClaimTypeAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async virtual Task DeleteAsync(Guid id)
        {
            await identityClaimTypeAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("actived-list")]
        public async virtual Task<ListResultDto<IdentityClaimTypeDto>> GetAllListAsync()
        {
            return await identityClaimTypeAppService.GetAllListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async virtual Task<IdentityClaimTypeDto> GetAsync(Guid id)
        {
            return await identityClaimTypeAppService.GetAsync(id);
        }

        [HttpGet]
        public async virtual Task<PagedResultDto<IdentityClaimTypeDto>> GetListAsync(IdentityClaimTypeGetByPagedDto input)
        {
            return await identityClaimTypeAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async virtual Task<IdentityClaimTypeDto> UpdateAsync(Guid id, IdentityClaimTypeUpdateDto input)
        {
            return await identityClaimTypeAppService.UpdateAsync(id, input);
        }

    }
}
