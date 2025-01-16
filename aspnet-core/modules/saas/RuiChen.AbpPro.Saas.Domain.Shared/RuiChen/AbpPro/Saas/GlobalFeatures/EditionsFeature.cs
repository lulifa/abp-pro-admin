using Volo.Abp.GlobalFeatures;

namespace RuiChen.AbpPro.Saas
{
    [GlobalFeatureName(Name)]
    public class EditionsFeature : GlobalFeature
    {
        public const string Name = "Saas.Editions";

        internal EditionsFeature(GlobalSaasFeatures module) : base(module)
        {
        }
    }
}
