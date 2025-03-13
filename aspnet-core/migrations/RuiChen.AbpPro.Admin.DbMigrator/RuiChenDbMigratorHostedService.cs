using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuiChen.AbpPro.Admin.EntityFrameworkCore;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;

namespace RuiChen.AbpPro.Admin.DbMigrator
{
    public class RuiChenDbMigratorHostedService : IHostedService
    {

        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IConfiguration _configuration;

        public RuiChenDbMigratorHostedService(
            IHostApplicationLifetime hostApplicationLifetime,
            IConfiguration configuration)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var application = await AbpApplicationFactory
                .CreateAsync<RuiChenDbMigratorModule>(options =>
                {
                    options.Services.ReplaceConfiguration(_configuration);
                    options.UseAutofac();
                    options.Services.AddLogging(c => c.AddSerilog());
                    options.AddDataMigrationEnvironment();
                });
            await application.InitializeAsync();

            await application
                .ServiceProvider
                .GetRequiredService<RuiChenMigrationService>()
                .CheckAndApplyDatabaseMigrationsAsync();

            await application.ShutdownAsync();

            _hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
