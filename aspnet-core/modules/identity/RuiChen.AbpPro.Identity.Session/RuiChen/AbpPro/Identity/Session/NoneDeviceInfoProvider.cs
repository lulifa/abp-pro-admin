using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.Identity
{
    [Dependency(ServiceLifetime.Singleton, TryRegister = true)]
    public class NoneDeviceInfoProvider : IDeviceInfoProvider
    {
        public string ClientIpAddress => "::1";

        public static DeviceInfo DeviceInfo => new DeviceInfo("unknown", "unknown", "unknown", "unknown");

        public virtual Task<DeviceInfo> GetDeviceInfoAsync()
        {
            return Task.FromResult(DeviceInfo);
        }
    }
}
