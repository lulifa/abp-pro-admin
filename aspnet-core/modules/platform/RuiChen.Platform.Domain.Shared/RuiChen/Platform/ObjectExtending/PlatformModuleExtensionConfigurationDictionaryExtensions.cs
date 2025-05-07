using Volo.Abp.ObjectExtending.Modularity;

namespace RuiChen.Platform
{
    public static class PlatformModuleExtensionConfigurationDictionaryExtensions
    {
        public static ModuleExtensionConfigurationDictionary ConfigurePlatform(
            this ModuleExtensionConfigurationDictionary modules,
            Action<PlatformModuleExtensionConfiguration> configureAction)
        {
            return modules.ConfigureModule(
                PlatformModuleExtensionConsts.ModuleName,
                configureAction
            );
        }
    }
}
