using Volo.Abp.ObjectExtending.Modularity;

namespace RuiChen.Platform
{
    public class PlatformModuleExtensionConfiguration : ModuleExtensionConfiguration
    {
        public PlatformModuleExtensionConfiguration ConfigureRoute(
        Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(
                PlatformModuleExtensionConsts.EntityNames.Route,
                configureAction
            );
        }
    }
}
