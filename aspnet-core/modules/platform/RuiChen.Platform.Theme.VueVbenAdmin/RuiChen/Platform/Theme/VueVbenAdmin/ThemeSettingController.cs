using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace RuiChen.Platform
{
    [Controller]
    [RemoteService(Name = PlatformRemoteServiceConsts.RemoteServiceName)]
    [Route("api/platform/theme/vue-vben-admin")]
    public class ThemeSettingController : AbpControllerBase, IThemeSettingAppService
    {
        protected IThemeSettingAppService ThemeSettingAppService { get; }

        public ThemeSettingController(
            IThemeSettingAppService themeSettingAppService)
        {
            ThemeSettingAppService = themeSettingAppService;
        }

        [HttpGet]
        public Task<ThemeSettingDto> GetAsync()
        {
            return ThemeSettingAppService.GetAsync();
        }

        [HttpPut]
        [Authorize]
        [Route("change")]
        public Task ChangeAsync(ThemeSettingDto input)
        {
            return ThemeSettingAppService.ChangeAsync(input);
        }
    }
}
