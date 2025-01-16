using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    public class GlobalSaasFeatures : GlobalModuleFeatures
    {
        public const string ModuleName = "Saas";

        public EditionFeature Editions => GetFeature<EditionFeature>();

        public GlobalSaasFeatures(GlobalFeatureManager featureManager) : base(featureManager)
        {
            AddFeature(new EditionFeature(this));
        }
    }
}
