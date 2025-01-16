using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    public class GlobalSaasFeatures : GlobalModuleFeatures
    {
        public const string ModuleName = "Saas";

        public EditionsFeature Editions => GetFeature<EditionsFeature>();

        public GlobalSaasFeatures(GlobalFeatureManager featureManager) : base(featureManager)
        {
            AddFeature(new EditionsFeature(this));
        }
    }
}
