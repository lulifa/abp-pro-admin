namespace RuiChen.AbpPro.Identity
{
    public interface IDeviceInfoProvider
    {
        string ClientIpAddress { get; }

        Task<DeviceInfo> GetDeviceInfoAsync();

    }
}
