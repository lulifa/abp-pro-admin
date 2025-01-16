using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    [GlobalFeatureName(Name)]
    public class EditionFeature : GlobalFeature
    {
        public const string Name = "Saas.Editions";

        internal EditionFeature(GlobalSaasFeatures module) : base(module)
        {
        }
    }
}
