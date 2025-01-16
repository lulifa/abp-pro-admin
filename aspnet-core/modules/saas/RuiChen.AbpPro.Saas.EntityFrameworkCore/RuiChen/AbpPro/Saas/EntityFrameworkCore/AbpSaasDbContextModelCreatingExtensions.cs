using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    public static class AbpSaasDbContextModelCreatingExtensions
    {
        public static void ConfigureSaas(
        this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            if (builder.IsTenantOnlyDatabase())
            {
                return;
            }

            if (GlobalFeatureManager.Instance.IsEnabled<EditionFeature>())
            {

                builder.Entity<Edition>(b =>
                {
                    b.ToTable(AbpSaasDbProperties.DbTablePrefix + "Editions", AbpSaasDbProperties.DbSchema);

                    b.ConfigureByConvention();

                    b.Property(t => t.DisplayName)
                        .HasMaxLength(EditionConsts.MaxDisplayNameLength)
                        .IsRequired();

                    b.HasIndex(u => u.DisplayName);

                    b.ApplyObjectExtensionMappings();
                });
            }
            else
            {
                builder.Ignore<Edition>();
            }

            builder.Entity<Tenant>(b =>
            {
                b.ToTable(AbpSaasDbProperties.DbTablePrefix + "Tenants", AbpSaasDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.Property(t => t.Name).IsRequired().HasMaxLength(TenantConsts.MaxNameLength);
                b.Property(t => t.NormalizedName).HasMaxLength(TenantConsts.MaxNameLength);

                b.HasMany(u => u.ConnectionStrings).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();

                b.HasIndex(u => u.Name);
                b.HasIndex(u => u.NormalizedName);

                b.ApplyObjectExtensionMappings();
            });

            builder.Entity<TenantConnectionString>(b =>
            {
                b.ToTable(AbpSaasDbProperties.DbTablePrefix + "TenantConnectionStrings", AbpSaasDbProperties.DbSchema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.TenantId, x.Name });

                b.Property(cs => cs.Name).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxNameLength);
                b.Property(cs => cs.Value).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxValueLength);

                b.ApplyObjectExtensionMappings();
            });

            builder.TryConfigureObjectExtensions<SaasDbContext>();
        }
    }
}
