using Volo.Abp.GlobalFeatures;
using Volo.Abp;
using JetBrains.Annotations;

namespace RuiChen.AbpPro.Saas
{
    public static class GlobalModuleFeaturesDictionarySaasExtensions
    {

        public static GlobalSaasFeatures Saas(
        [NotNull] this GlobalModuleFeaturesDictionary modules)
        {
            Check.NotNull(modules, nameof(modules));

            return modules
                    .GetOrAdd(
                        GlobalSaasFeatures.ModuleName,
                        _ => new GlobalSaasFeatures(modules.FeatureManager)
                    )
                as GlobalSaasFeatures;
        }

        public static GlobalModuleFeaturesDictionary Saas(
            [NotNull] this GlobalModuleFeaturesDictionary modules,
            [NotNull] Action<GlobalSaasFeatures> configureAction)
        {
            Check.NotNull(configureAction, nameof(configureAction));

            configureAction(modules.Saas());

            return modules;
        }

    }
}
