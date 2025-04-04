﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Saas
{
    [Route("api/saas/tenants")]
    [ControllerName("SaasTenant")]
    public class TenantController : AbpSaasControllerBase, ITenantAppService
    {
        private readonly ITenantAppService tenantAppService;

        public TenantController(ITenantAppService tenantAppService)
        {
            this.tenantAppService = tenantAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TenantDto> GetAsync(Guid id)
        {
            return tenantAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("by-name/{name}")]
        public virtual Task<TenantDto> GetAsync(string name)
        {
            return tenantAppService.GetAsync(name);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TenantDto>> GetListAsync(TenantGetListInput input)
        {
            return tenantAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            return tenantAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
        {
            return tenantAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return tenantAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}/connection-string/{name}")]
        public virtual Task<TenantConnectionStringDto> GetConnectionStringAsync(Guid id, string name)
        {
            return tenantAppService.GetConnectionStringAsync(id, name);
        }

        [HttpGet]
        [Route("{id}/connection-string")]
        public virtual Task<ListResultDto<TenantConnectionStringDto>> GetConnectionStringAsync(Guid id)
        {
            return tenantAppService.GetConnectionStringAsync(id);
        }

        [HttpPut]
        [Route("{id}/connection-string")]
        public virtual Task<TenantConnectionStringDto> SetConnectionStringAsync(Guid id, TenantConnectionStringCreateOrUpdate input)
        {
            return tenantAppService.SetConnectionStringAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}/connection-string/{name}")]
        public virtual Task DeleteConnectionStringAsync(Guid id, string name)
        {
            return tenantAppService.DeleteConnectionStringAsync(id, name);
        }

    }
}
