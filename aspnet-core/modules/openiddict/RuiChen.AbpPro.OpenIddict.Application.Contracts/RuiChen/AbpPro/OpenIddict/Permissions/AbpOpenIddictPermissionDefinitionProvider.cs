using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict.Localization;

namespace RuiChen.AbpPro.OpenIddict
{
    public class AbpOpenIddictPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var openiddictGroup = context.GetGroupOrNull(AbpOpenIddictPermissions.GroupName);

            if (openiddictGroup == null)
            {
                openiddictGroup = context.AddGroup(AbpOpenIddictPermissions.GroupName, L("Permissions:OpenIddict"));
            }

            var applications = openiddictGroup.AddPermission(
                AbpOpenIddictPermissions.Applications.Default,
                L("Permissions:Applications"),
                MultiTenancySides.Host);
            applications.AddChild(
                AbpOpenIddictPermissions.Applications.Create,
                L("Permissions:Create"),
                MultiTenancySides.Host);
            applications.AddChild(
                AbpOpenIddictPermissions.Applications.Update,
                L("Permissions:Update"),
                MultiTenancySides.Host);
            applications.AddChild(
                AbpOpenIddictPermissions.Applications.Delete,
                L("Permissions:Delete"),
                MultiTenancySides.Host);
            applications.AddChild(
                AbpOpenIddictPermissions.Applications.ManagePermissions,
                L("Permissions:ManagePermissions"),
                MultiTenancySides.Host);
            applications.AddChild(
                AbpOpenIddictPermissions.Applications.ManageSecret,
                L("Permissions:ManageSecret"),
                MultiTenancySides.Host);

            var authorizations = openiddictGroup.AddPermission(
                AbpOpenIddictPermissions.Authorizations.Default,
                L("Permissions:Authorizations"),
                MultiTenancySides.Host);
            authorizations.AddChild(
                AbpOpenIddictPermissions.Authorizations.Delete,
                L("Permissions:Delete"),
                MultiTenancySides.Host);

            var scopes = openiddictGroup.AddPermission(
                AbpOpenIddictPermissions.Scopes.Default,
                L("Permissions:Scopes"),
                MultiTenancySides.Host);
            scopes.AddChild(
                AbpOpenIddictPermissions.Scopes.Create,
                L("Permissions:Create"),
                MultiTenancySides.Host);
            scopes.AddChild(
                AbpOpenIddictPermissions.Scopes.Update,
                L("Permissions:Update"),
                MultiTenancySides.Host);
            scopes.AddChild(
                AbpOpenIddictPermissions.Scopes.Delete,
                L("Permissions:Delete"),
                MultiTenancySides.Host);

            var tokens = openiddictGroup.AddPermission(
                AbpOpenIddictPermissions.Tokens.Default,
                L("Permissions:Tokens"),
                MultiTenancySides.Host);
            tokens.AddChild(
                AbpOpenIddictPermissions.Tokens.Delete,
                L("Permissions:Delete"),
                MultiTenancySides.Host);
        }

        protected virtual LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpOpenIddictResource>(name);
        }
    }
}
