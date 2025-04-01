using Microsoft.Extensions.Logging;
using RuiChen.AbpPro.Data.DbMigrator;
using RuiChen.AbpPro.Saas;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    public class RuiChenMigrationService : EfCoreRuntimeDbMigratorBase<RuiChenMigrationDbContext>, ITransientDependency
    {
        protected IDataSeeder DataSeeder { get; }
        protected ITenantRepository TenantRepository { get; }
        public RuiChenMigrationService(
            IUnitOfWorkManager unitOfWorkManager,
            IServiceProvider serviceProvider,
            ICurrentTenant currentTenant,
            IAbpDistributedLock abpDistributedLock,
            IDistributedEventBus distributedEventBus,
            ILoggerFactory loggerFactory,
            IDataSeeder dataSeeder,
            ITenantRepository tenantRepository)
            : base(ConnectionStringNameAttribute.GetConnStringName<RuiChenMigrationDbContext>(), unitOfWorkManager, serviceProvider, currentTenant, abpDistributedLock, distributedEventBus, loggerFactory)
        {
            DataSeeder = dataSeeder;
            TenantRepository = tenantRepository;
        }
        protected async override Task LockAndApplyDatabaseMigrationsAsync()
        {
            await base.LockAndApplyDatabaseMigrationsAsync();

            var tenants = await TenantRepository.GetListAsync();

            foreach (var tenant in tenants.Where(x => x.IsActive))
            {
                await LockAndApplyDatabaseWithTenantMigrationsAsync(tenant.Id);
            }

        }

        protected async override Task SeedAsync()
        {
            await DataSeeder.SeedAsync(CurrentTenant.Id);
        }
    }
}
