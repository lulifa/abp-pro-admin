using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace RuiChen.AbpPro.Identity
{
    public class IdentitySessionCleanupBackgroundWorker : AsyncPeriodicBackgroundWorkerBase
    {
        protected IdentitySessionCleanupOptions Options { get; }

        public IdentitySessionCleanupBackgroundWorker(
            AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            IOptions<IdentitySessionCleanupOptions> options)
            : base(timer, serviceScopeFactory)
        {
            Options = options.Value;
            timer.Period = Options.CleanupPeriod;
        }

        protected async override Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            if (!Options.IsCleanupEnabled)
            {
                return;
            }

            await workerContext.ServiceProvider.GetRequiredService<IdentitySessionCleanupService>().CleanAsync();
        }
    }
}
