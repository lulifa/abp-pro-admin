using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace RuiChen.AbpPro.Saas
{
    public class SaasFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {

            var group = context.AddGroup(SaasFeatures.GroupName, L("Features:Saas"));

            group.AddFeature(
                name: SaasFeatures.Tenant.RecycleStrategy,
                defaultValue: $"{RecycleStrategy.Reserve}",
                displayName: L("Features:RecycleStrategy"),
                description: L("Features:RecycleStrategyDesc"),
                valueType: new SelectionStringValueType
                {
                    ItemSource = new StaticSelectionStringValueItemSource(
                    new LocalizableSelectionStringValueItem
                    {
                        Value = RecycleStrategy.Reserve.ToString(),
                        DisplayText = new LocalizableStringInfo(LocalizationResourceNameAttribute.GetName(typeof(AbpSaasResource)), "RecycleStrategy:Reserve")
                    },
                    new LocalizableSelectionStringValueItem
                    {
                        Value = RecycleStrategy.Recycle.ToString(),
                        DisplayText = new LocalizableStringInfo(LocalizationResourceNameAttribute.GetName(typeof(AbpSaasResource)), "RecycleStrategy:Recycle")
                    })
                },
                isAvailableToHost: false
            );

            group.AddFeature(
                name: SaasFeatures.Tenant.ExpirationReminderDays,
                defaultValue: $"{15}",
                displayName: L("Features:ExpirationReminderDays"),
                description: L("Features:ExpirationReminderDaysDesc"),
                valueType: new FreeTextStringValueType(new NumericValueValidator(1, 30)),
                isAvailableToHost: false
            );

            group.AddFeature(
                name: SaasFeatures.Tenant.ExpiredRecoveryTime,
                defaultValue: $"{15}",
                displayName: L("Features:ExpiredRecoveryTime"),
                description: L("Features:ExpiredRecoveryTimeDesc"),
                valueType: new FreeTextStringValueType(new NumericValueValidator(1, 30)),
                isAvailableToHost: false
            );

        }

        protected ILocalizableString L(string name)
        {
            return LocalizableString.Create<AbpSaasResource>(name);
        }

    }
}
