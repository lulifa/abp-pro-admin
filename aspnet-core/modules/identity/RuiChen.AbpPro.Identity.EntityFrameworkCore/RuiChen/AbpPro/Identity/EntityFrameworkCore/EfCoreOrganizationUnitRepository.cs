﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Specifications;
using VoloEfCoreOrganizationUnitRepository = Volo.Abp.Identity.EntityFrameworkCore.EfCoreOrganizationUnitRepository;

namespace RuiChen.AbpPro.Identity
{
    public class EfCoreOrganizationUnitRepository : VoloEfCoreOrganizationUnitRepository, IOrganizationUnitRepository
    {
        public EfCoreOrganizationUnitRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async virtual Task<int> GetCountAsync(ISpecification<OrganizationUnit> specification, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(specification.ToExpression())
                .CountAsync(GetCancellationToken(cancellationToken));
        }

        public async virtual Task<List<OrganizationUnit>> GetListAsync(ISpecification<OrganizationUnit> specification, string sorting = nameof(OrganizationUnit.Code), int maxResultCount = 10, int skipCount = 0, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (sorting.IsNullOrWhiteSpace())
            {
                sorting = nameof(OrganizationUnit.Code);
            }
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .Where(specification.ToExpression())
                .OrderBy(sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

    }
}
