using Volo.Abp.ObjectExtending.Modularity;

namespace RuiChen.AbpPro.Saas
{
    public static class SaasModuleExtensionConfigurationDictionaryExtensions
    {
        public static ModuleExtensionConfigurationDictionary ConfigureSaas(
            this ModuleExtensionConfigurationDictionary modules,
            Action<SaasModuleExtensionConfiguration> configureAction)
        {
            return modules.ConfigureModule(
                SaasModuleExtensionConsts.ModuleName,
                configureAction
            );
        }
    }
}
