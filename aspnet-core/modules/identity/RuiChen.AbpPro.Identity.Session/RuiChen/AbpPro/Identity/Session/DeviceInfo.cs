namespace RuiChen.AbpPro.Identity
{
    public class DeviceInfo
    {
        public DeviceInfo(string device, string description, string clientIpAddress, string ipRegion)
        {
            Device = device;
            Description = description;
            ClientIpAddress = clientIpAddress;
            IpRegion = ipRegion;
        }

        public string Device { get; }
        public string Description { get; }
        public string ClientIpAddress { get; }
        public string IpRegion { get; }

    }
}
