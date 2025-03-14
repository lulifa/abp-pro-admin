﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    [Route("api/identity/organization-units")]
    [ControllerName("IdentityOrganizationUnit")]
    public class OrganizationUnitController : IdentityControllerBase, IOrganizationUnitAppService
    {
        private readonly IOrganizationUnitAppService organizationUnitAppService;

        public OrganizationUnitController(IOrganizationUnitAppService organizationUnitAppService)
        {
            this.organizationUnitAppService = organizationUnitAppService;
        }

        [HttpPost]
        public async virtual Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            return await organizationUnitAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async virtual Task DeleteAsync(Guid id)
        {
            await organizationUnitAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("root-node")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetRootAsync()
        {
            return await organizationUnitAppService.GetRootAsync();
        }

        [HttpGet]
        [Route("find-children")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> FindChildrenAsync(OrganizationUnitGetChildrenDto input)
        {
            return await organizationUnitAppService.FindChildrenAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public async virtual Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            return await organizationUnitAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("last-children")]
        public async virtual Task<OrganizationUnitDto> GetLastChildOrNullAsync(Guid? parentId)
        {
            return await organizationUnitAppService.GetLastChildOrNullAsync(parentId);
        }

        [HttpGet]
        [Route("all")]
        public async virtual Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync(GetOrganizationUnitsAdvancedInput input)
        {
            return await organizationUnitAppService.GetAllListAsync(input);
        }

        [HttpGet]
        public async virtual Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitGetByPagedDto input)
        {
            return await organizationUnitAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}/role-names")]
        public async virtual Task<ListResultDto<string>> GetRoleNamesAsync(Guid id)
        {
            return await organizationUnitAppService.GetRoleNamesAsync(id);
        }

        [HttpGet]
        [Route("{id}/unadded-roles")]
        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetUnaddedRolesAsync(Guid id, OrganizationUnitGetUnaddedRoleByPagedDto input)
        {
            return await organizationUnitAppService.GetUnaddedRolesAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/roles")]
        public async virtual Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input)
        {
            return await organizationUnitAppService.GetRolesAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/unadded-users")]
        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUnaddedUsersAsync(Guid id, OrganizationUnitGetUnaddedUserByPagedDto input)
        {
            return await organizationUnitAppService.GetUnaddedUsersAsync(id, input);
        }

        [HttpGet]
        [Route("{id}/users")]
        public async virtual Task<PagedResultDto<IdentityUserDto>> GetUsersAsync(Guid id, GetIdentityUsersInput input)
        {
            return await organizationUnitAppService.GetUsersAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/move")]
        public async virtual Task MoveAsync(Guid id, OrganizationUnitMoveDto input)
        {
            await organizationUnitAppService.MoveAsync(id, input);
        }

        [HttpPut]
        [Route("{id}")]
        public async virtual Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            return await organizationUnitAppService.UpdateAsync(id, input);
        }

        [HttpPost]
        [Route("{id}/users")]
        public async virtual Task AddUsersAsync(Guid id, OrganizationUnitAddUserDto input)
        {
            await organizationUnitAppService.AddUsersAsync(id, input);
        }

        [HttpPost]
        [Route("{id}/roles")]
        public async virtual Task AddRolesAsync(Guid id, OrganizationUnitAddRoleDto input)
        {
            await organizationUnitAppService.AddRolesAsync(id, input);
        }

    }
}
