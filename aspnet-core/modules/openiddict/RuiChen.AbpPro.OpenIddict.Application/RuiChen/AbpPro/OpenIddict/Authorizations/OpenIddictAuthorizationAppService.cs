using Microsoft.AspNetCore.Authorization;
using OpenIddict.Abstractions;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Authorizations;

namespace RuiChen.AbpPro.OpenIddict
{
    [Authorize(AbpOpenIddictPermissions.Authorizations.Default)]
    public class OpenIddictAuthorizationAppService : OpenIddictApplicationServiceBase, IOpenIddictAuthorizationAppService
    {
        private readonly IOpenIddictAuthorizationManager authorizationManager;
        private readonly IRepository<OpenIddictAuthorization, Guid> authorizationRepository;
        private readonly AbpOpenIddictIdentifierConverter identifierConverter;

        public OpenIddictAuthorizationAppService(IOpenIddictAuthorizationManager authorizationManager, IRepository<OpenIddictAuthorization, Guid> authorizationRepository, AbpOpenIddictIdentifierConverter identifierConverter)
        {
            this.authorizationManager = authorizationManager;
            this.authorizationRepository = authorizationRepository;
            this.identifierConverter = identifierConverter;
        }

        [Authorize(AbpOpenIddictPermissions.Authorizations.Delete)]
        public async virtual Task DeleteAsync(Guid id)
        {
            var authorization = await authorizationManager.FindByIdAsync(identifierConverter.ToString(id));

            await authorizationManager.DeleteAsync(authorization);

        }

        [Authorize(AbpOpenIddictPermissions.Authorizations.Default)]
        public async virtual Task<OpenIddictAuthorizationDto> GetAsync(Guid id)
        {
            var authorization = await authorizationRepository.GetAsync(id);

            return authorization.ToDto(JsonSerializer);

        }

        public async virtual Task<PagedResultDto<OpenIddictAuthorizationDto>> GetListAsync(OpenIddictAuthorizationGetListInput input)
        {
            var queryable = await authorizationRepository.GetQueryableAsync();
            if (input.ClientId.HasValue)
            {
                queryable = queryable.Where(x => x.ApplicationId == input.ClientId);
            }
            if (input.BeginCreationTime.HasValue)
            {
                queryable = queryable.Where(x => x.CreationDate >= input.BeginCreationTime);
            }
            if (input.EndCreationTime.HasValue)
            {
                queryable = queryable.Where(x => x.CreationDate <= input.EndCreationTime);
            }
            if (!input.Status.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Status == input.Status);
            }
            if (!input.Type.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Type == input.Type);
            }
            if (!input.Subject.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Subject == input.Subject);
            }
            if (!input.Filter.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Subject.Contains(input.Filter) ||
                    x.Status.Contains(input.Filter) || x.Type.Contains(input.Filter) ||
                    x.Scopes.Contains(input.Filter) || x.Properties.Contains(input.Filter));
            }

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var sorting = input.Sorting;
            if (sorting.IsNullOrWhiteSpace())
            {
                sorting = $"{nameof(OpenIddictAuthorization.CreationDate)} DESC";
            }
            queryable = queryable
                .OrderBy(sorting)
                .PageBy(input.SkipCount, input.MaxResultCount);
            var entites = await AsyncExecuter.ToListAsync(queryable);

            return new PagedResultDto<OpenIddictAuthorizationDto>(totalCount,
                entites.Select(entity => entity.ToDto(JsonSerializer)).ToList());
        }
    }
}
