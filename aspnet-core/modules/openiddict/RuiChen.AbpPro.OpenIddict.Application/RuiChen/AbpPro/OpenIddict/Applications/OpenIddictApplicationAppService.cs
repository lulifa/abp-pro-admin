using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Applications;

namespace RuiChen.AbpPro.OpenIddict
{
    [Authorize(AbpOpenIddictPermissions.Applications.Default)]
    public class OpenIddictApplicationAppService : OpenIddictApplicationServiceBase, IOpenIddictApplicationAppService
    {
        private readonly IAbpApplicationManager applicationManager;
        private readonly IOpenIddictApplicationRepository applicationRepository;

        public OpenIddictApplicationAppService(IAbpApplicationManager applicationManager, IOpenIddictApplicationRepository applicationRepository)
        {
            this.applicationManager = applicationManager;
            this.applicationRepository = applicationRepository;
        }

        [Authorize(AbpOpenIddictPermissions.Applications.Create)]
        public async virtual Task<OpenIddictApplicationDto> CreateAsync(OpenIddictApplicationCreateDto input)
        {
            if (await applicationRepository.FindByClientIdAsync(input.ClientId) != null)
            {
                throw new BusinessException(OpenIddictApplicationErrorCodes.Applications.ClientIdExisted)
                .WithData(nameof(OpenIddictApplication.ClientId), input.ClientId);
            }

            var application = new OpenIddictApplication(GuidGenerator.Create())
            {
                ClientId = input.ClientId,
            };

            application = input.ToEntity(application, JsonSerializer);

            await applicationManager.CreateAsync(application.ToModel(), input.ClientSecret);

            application = await applicationRepository.FindByClientIdAsync(input.ClientId);

            return application.ToDto(JsonSerializer);

        }

        [Authorize(AbpOpenIddictPermissions.Applications.Delete)]
        public async virtual Task DeleteAsync(Guid id)
        {
            var application = await applicationRepository.GetAsync(id);

            await applicationManager.DeleteAsync(application);
        }

        [Authorize(AbpOpenIddictPermissions.Applications.Update)]
        public async virtual Task<OpenIddictApplicationDto> UpdateAsync(Guid id, OpenIddictApplicationUpdateDto input)
        {
            var application = await applicationRepository.GetAsync(id);

            application.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

            application = input.ToEntity(application, JsonSerializer);

            if (input.ClientSecret.IsNullOrWhiteSpace())
            {
                await applicationManager.UpdateAsync(application.ToModel());
            }
            else
            {
                await applicationManager.UpdateAsync(application.ToModel(), input.ClientSecret);
            }

            application = await applicationRepository.FindAsync(id);

            return application.ToDto(JsonSerializer);

        }

        public async virtual Task<OpenIddictApplicationDto> GetAsync(Guid id)
        {
            var application = await applicationRepository.GetAsync(id);

            return application.ToDto(JsonSerializer);
        }

        public async virtual Task<PagedResultDto<OpenIddictApplicationDto>> GetListAsync(OpenIddictApplicationGetListInput input)
        {
            var totalCount = await applicationRepository.GetCountAsync(input.Filter);

            var entities = await applicationRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount, input.Filter);

            var items = entities.Select(item => item.ToDto(JsonSerializer)).ToList();

            return new PagedResultDto<OpenIddictApplicationDto>(totalCount, items);

        }


    }
}
