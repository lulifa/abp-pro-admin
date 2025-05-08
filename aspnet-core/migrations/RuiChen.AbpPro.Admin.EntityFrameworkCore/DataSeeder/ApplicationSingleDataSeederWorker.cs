using Microsoft.Extensions.Hosting;
using Volo.Abp.Data;

namespace RuiChen.AbpPro.Admin.EntityFrameworkCore
{
    public class ApplicationSingleDataSeederWorker : BackgroundService
    {
        protected IDataSeeder DataSeeder { get; }

        public ApplicationSingleDataSeederWorker(IDataSeeder dataSeeder)
        {
            DataSeeder = dataSeeder;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DataSeeder.SeedAsync();
        }
    }
}
