namespace RuiChen.AbpPro.UI.Navigation
{
    public class NavigationDefinition
    {
        public NavigationDefinition(ApplicationMenu menu)
        {
            Menu = menu;
        }

        public ApplicationMenu Menu { get; }

    }
}
