namespace RuiChen.AbpPro.OpenIddict
{
    public class OpenIddictApplicationSettingsDto
    {
        public OpenIddictApplicationTokenLifetimesDto TokenLifetime { get; set; } = new OpenIddictApplicationTokenLifetimesDto();
    }
}
