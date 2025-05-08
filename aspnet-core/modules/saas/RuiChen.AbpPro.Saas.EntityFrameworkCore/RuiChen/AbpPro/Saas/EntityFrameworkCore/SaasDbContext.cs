using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.Saas
{
    [IgnoreMultiTenancy]
    [ConnectionStringName(AbpSaasDbProperties.ConnectionStringName)]
    public class SaasDbContext : AbpDbContext<SaasDbContext>, ISaasDbContext
    {
        public DbSet<Edition> Editions { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        public SaasDbContext(DbContextOptions<SaasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetMultiTenancySide(MultiTenancySides.Host);

            modelBuilder.ConfigureSaas();

        }

    }
}
