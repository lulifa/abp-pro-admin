using Microsoft.AspNetCore.Authorization;
using OpenIddict.Abstractions;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Tokens;

namespace RuiChen.AbpPro.OpenIddict
{
    [Authorize(AbpOpenIddictPermissions.Tokens.Default)]
    public class OpenIddictTokenAppService : OpenIddictApplicationServiceBase, IOpenIddictTokenAppService
    {
        private readonly IOpenIddictTokenManager tokenManager;
        private readonly IRepository<OpenIddictToken, Guid> tokenRepository;
        private readonly AbpOpenIddictIdentifierConverter identifierConverter;

        public OpenIddictTokenAppService(IOpenIddictTokenManager tokenManager, IRepository<OpenIddictToken, Guid> tokenRepository, AbpOpenIddictIdentifierConverter identifierConverter)
        {
            this.tokenManager = tokenManager;
            this.tokenRepository = tokenRepository;
            this.identifierConverter = identifierConverter;
        }

        [Authorize(AbpOpenIddictPermissions.Tokens.Delete)]
        public async virtual Task DeleteAsync(Guid id)
        {
            var token = await tokenManager.FindByIdAsync(identifierConverter.ToString(id));

            await tokenManager.DeleteAsync(token);

        }

        public async virtual Task<OpenIddictTokenDto> GetAsync(Guid id)
        {
            var token = await tokenRepository.GetAsync(id);

            return token.ToDto();
        }

        public async virtual Task<PagedResultDto<OpenIddictTokenDto>> GetListAsync(OpenIddictTokenGetListInput input)
        {
            var queryable = await tokenRepository.GetQueryableAsync();
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
            if (input.BeginExpirationDate.HasValue)
            {
                queryable = queryable.Where(x => x.ExpirationDate >= input.BeginExpirationDate);
            }
            if (input.EndExpirationDate.HasValue)
            {
                queryable = queryable.Where(x => x.ExpirationDate <= input.EndExpirationDate);
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
            if (!input.ReferenceId.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.ReferenceId == input.ReferenceId);
            }
            if (!input.Filter.IsNullOrWhiteSpace())
            {
                queryable = queryable.Where(x => x.Subject.Contains(input.Filter) ||
                    x.Status.Contains(input.Filter) || x.Type.Contains(input.Filter) ||
                    x.Payload.Contains(input.Filter) || x.Properties.Contains(input.Filter) ||
                    x.ReferenceId.Contains(input.ReferenceId));
            }

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var sorting = input.Sorting;
            if (sorting.IsNullOrWhiteSpace())
            {
                sorting = $"{nameof(OpenIddictToken.CreationDate)} DESC";
            }

            queryable = queryable
                .OrderBy(sorting)
                .PageBy(input.SkipCount, input.MaxResultCount);
            var entites = await AsyncExecuter.ToListAsync(queryable);

            return new PagedResultDto<OpenIddictTokenDto>(totalCount,
                entites.Select(entity => entity.ToDto()).ToList());
        }
    }
}
