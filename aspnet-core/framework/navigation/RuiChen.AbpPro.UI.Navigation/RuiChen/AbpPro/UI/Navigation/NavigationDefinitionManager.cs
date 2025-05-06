using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Immutable;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.UI.Navigation
{
    public class NavigationDefinitionManager : INavigationDefinitionManager, ISingletonDependency
    {
        public Lazy<IList<NavigationDefinition>> NavigationDefinitions { get; }

        public AbpNavigationOptions Options { get; }

        public IServiceProvider ServiceProvider { get; }

        public NavigationDefinitionManager(
            IOptions<AbpNavigationOptions> options,
            IServiceProvider serviceProvider)
        {
            Options = options.Value;

            ServiceProvider = serviceProvider;

            NavigationDefinitions = new Lazy<IList<NavigationDefinition>>(GetNavigationDefinitions, true);

        }

        public virtual IReadOnlyList<NavigationDefinition> GetAll()
        {
            return NavigationDefinitions.Value.ToImmutableList();
        }

        public virtual IList<NavigationDefinition> GetNavigationDefinitions()
        {
            var navigations = new List<NavigationDefinition>();

            using (var scope = ServiceProvider.CreateScope())
            {
                var providers = Options.NavigationDefinitionProviders
                                     .Select(p => scope.ServiceProvider.GetRequiredService(p) as INavigationDefinitionProvider)
                                     .ToList();

                foreach (var provider in providers)
                {
                    provider.Define(new NavigationDefinitionContext(navigations));
                }

                return navigations;

            }

        }

    }
}
