namespace RuiChen.AbpPro.UI.Navigation
{
    public class NavigationDefinitionContext : INavigationDefinitionContext
    {
        protected List<NavigationDefinition> Navigations { get; }
        public NavigationDefinitionContext(List<NavigationDefinition> navigations)
        {
            Navigations = navigations;
        }

        public void Add(params NavigationDefinition[] definitions)
        {
            if (definitions.IsNullOrEmpty())
            {
                return;
            }

            Navigations.AddRange(definitions);

        }
    }
}
