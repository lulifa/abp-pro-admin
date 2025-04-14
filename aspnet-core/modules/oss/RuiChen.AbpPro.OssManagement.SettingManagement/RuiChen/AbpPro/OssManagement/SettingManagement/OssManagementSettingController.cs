using Microsoft.AspNetCore.Mvc;
using RuiChen.AbpPro.SettingManagement;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace RuiChen.AbpPro.OssManagement
{
    [RemoteService(Name = OssManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("settingManagement")]
    [Route("api/setting-management/oss-management")]
    public class OssManagementSettingController : AbpControllerBase, IOssManagementSettingAppService
    {
        protected IOssManagementSettingAppService WeChatSettingAppService { get; }

        public OssManagementSettingController(
            IOssManagementSettingAppService weChatSettingAppService)
        {
            WeChatSettingAppService = weChatSettingAppService;
        }

        [HttpGet]
        [Route("by-current-tenant")]
        public async virtual Task<SettingGroupResult> GetAllForCurrentTenantAsync()
        {
            return await WeChatSettingAppService.GetAllForCurrentTenantAsync();
        }

        [HttpGet]
        [Route("by-global")]
        public async virtual Task<SettingGroupResult> GetAllForGlobalAsync()
        {
            return await WeChatSettingAppService.GetAllForGlobalAsync();
        }
    }
}
