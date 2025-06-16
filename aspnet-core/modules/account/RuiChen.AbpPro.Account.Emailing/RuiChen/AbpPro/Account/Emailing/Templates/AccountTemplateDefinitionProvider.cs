using Volo.Abp.Emailing.Templates;
using Volo.Abp.Localization;
using Volo.Abp.TextTemplating;

namespace RuiChen.AbpPro.Account;

public class AccountTemplateDefinitionProvider : TemplateDefinitionProvider
{
    public override void Define(ITemplateDefinitionContext context)
    {
        context.Add(
            new TemplateDefinition(
                AccountEmailTemplates.MailSecurityVerifyLink,
                displayName: L($"TextTemplate:{AccountEmailTemplates.MailSecurityVerifyLink}"),
                layout: StandardEmailTemplates.Layout,
                localizationResource: typeof(AccountEmailingResource)
            ).WithVirtualFilePath("/RuiChen/AbpPro/Account/Emailing/Templates/MailSecurityVerify.tpl", true),
            new TemplateDefinition(
                AccountEmailTemplates.MailConfirmLink,
                displayName: L($"TextTemplate:{AccountEmailTemplates.MailConfirmLink}"),
                layout: StandardEmailTemplates.Layout,
                localizationResource: typeof(AccountEmailingResource)
            ).WithVirtualFilePath("/RuiChen/AbpPro/Account/Emailing/Templates/MailConfirm.tpl", true)
        );
    }

    private static ILocalizableString L(string name)
    {
        return LocalizableString.Create<AccountEmailingResource>(name);
    }
}
