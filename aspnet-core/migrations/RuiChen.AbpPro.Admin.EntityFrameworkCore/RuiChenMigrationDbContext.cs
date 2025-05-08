using Microsoft.EntityFrameworkCore;
using RuiChen.AbpPro.Saas;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using RuiChen.Platform;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    [ConnectionStringName("SingleDbMigrator")]
    public class RuiChenMigrationDbContext : AbpDbContext<RuiChenMigrationDbContext>
    {
        public RuiChenMigrationDbContext(DbContextOptions<RuiChenMigrationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigureOpenIddict();
            modelBuilder.ConfigureSaas();
            modelBuilder.ConfigurePlatform();
            modelBuilder.ConfigureFeatureManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigurePermissionManagement();
        }
    }
}
