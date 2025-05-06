using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.UI.Navigation
{
    public class NavigationDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private IServiceProvider ServiceProvider { get; }
        private ICurrentTenant CurrentTenant { get; }
        private INavigationProvider NavigationProvider { get; }
        private AbpNavigationOptions Options { get; }

        private readonly Lazy<List<INavigationSeedContributor>> LazyContributors;

        public NavigationDataSeedContributor(
            IServiceProvider serviceProvider,
            ICurrentTenant currentTenant,
            INavigationProvider navigationProvider,
            IOptions<AbpNavigationOptions> options)
        {
            ServiceProvider = serviceProvider;
            CurrentTenant = currentTenant;
            NavigationProvider = navigationProvider;
            Options = options.Value;
            LazyContributors = new Lazy<List<INavigationSeedContributor>>(CreateContributors);
        }

        public List<INavigationSeedContributor> Contributors => LazyContributors.Value;

        public async virtual Task SeedAsync(DataSeedContext context)
        {
            using (CurrentTenant.Change(context.TenantId))
            {
                var menus = await NavigationProvider.GetAllAsync();

                var multiTenancySides = CurrentTenant.IsAvailable ? MultiTenancySides.Tenant : MultiTenancySides.Host;

                var seedContext = new NavigationSeedContext(menus, multiTenancySides);

                foreach (var contributor in Contributors)
                {
                    await contributor.SeedAsync(seedContext);
                }
            }
        }

        private List<INavigationSeedContributor> CreateContributors()
        {
            return Options.NavigationSeedContributors
                          .Select(type => ServiceProvider.GetRequiredService(type) as INavigationSeedContributor)
                          .ToList();
        }

    }
}
