using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    public class RuiChenMigrationDbContextFactory : IDesignTimeDbContextFactory<RuiChenMigrationDbContext>
    {
        public RuiChenMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var connectionString = configuration.GetConnectionString("Default");

            var builder = new DbContextOptionsBuilder<RuiChenMigrationDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new RuiChenMigrationDbContext(builder!.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RuiChen.AbpPro.Admin.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Production.json", optional: true);

            return builder.Build();
        }
    }
}
