using Volo.Abp.Collections;

namespace RuiChen.AbpPro.UI.Navigation
{
    public class AbpNavigationOptions
    {
        public AbpNavigationOptions()
        {
            NavigationDefinitionProviders = new TypeList<INavigationDefinitionProvider>();

            NavigationSeedContributors = new TypeList<INavigationSeedContributor>();
        }

        public ITypeList<INavigationDefinitionProvider> NavigationDefinitionProviders { get; }

        public ITypeList<INavigationSeedContributor> NavigationSeedContributors { get; }

    }
}
