using System.Collections.Immutable;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.UI.Navigation
{
    public class NavigationProvider : INavigationProvider, ITransientDependency
    {
        public INavigationDefinitionManager NavigationDefinitionManager { get; }

        public NavigationProvider(INavigationDefinitionManager navigationDefinitionManager)
        {
            NavigationDefinitionManager = navigationDefinitionManager;
        }

        public Task<IReadOnlyCollection<ApplicationMenu>> GetAllAsync()
        {
            var navigations = new List<ApplicationMenu>();

            var navigationDefinitions = NavigationDefinitionManager.GetAll();

            foreach (var navigationDefinition in navigationDefinitions)
            {
                navigations.Add(navigationDefinition.Menu);
            }

            IReadOnlyCollection<ApplicationMenu> menus = navigations.ToImmutableList();

            return Task.FromResult(menus);

        }
    }
}
