using Volo.Abp.Application.Services;

namespace RuiChen.Platform
{
    public interface IThemeSettingAppService : IApplicationService
    {
        Task<ThemeSettingDto> GetAsync();

        Task ChangeAsync(ThemeSettingDto input);
    }
}
