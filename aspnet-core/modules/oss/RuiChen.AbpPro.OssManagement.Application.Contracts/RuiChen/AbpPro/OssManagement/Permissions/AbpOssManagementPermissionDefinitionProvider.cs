using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Features;
using Volo.Abp.Localization;

namespace RuiChen.AbpPro.OssManagement
{
    public class AbpOssManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var ossManagement = context.AddGroup(AbpOssManagementPermissions.GroupName, L("Permission:OssManagement"));

            var container = ossManagement.AddPermission(AbpOssManagementPermissions.Container.Default, L("Permission:Container"));
            container.AddChild(AbpOssManagementPermissions.Container.Create, L("Permission:Create"));
            container.AddChild(AbpOssManagementPermissions.Container.Delete, L("Permission:Delete"));

            var ossobject = ossManagement
                .AddPermission(AbpOssManagementPermissions.OssObject.Default, L("Permission:OssObject"))
                .RequireFeatures(AbpOssManagementFeatureNames.OssObject.Enable);
            ossobject
                .AddChild(AbpOssManagementPermissions.OssObject.Create, L("Permission:Create"))
                .RequireFeatures(AbpOssManagementFeatureNames.OssObject.UploadFile);
            ossobject.AddChild(AbpOssManagementPermissions.OssObject.Delete, L("Permission:Delete"));
            ossobject
                .AddChild(AbpOssManagementPermissions.OssObject.Download, L("Permission:Download"))
                .RequireFeatures(AbpOssManagementFeatureNames.OssObject.DownloadFile);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpOssManagementResource>(name);
        }
    }
}
