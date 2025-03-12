using Microsoft.Extensions.Options;
using RuiChen.AbpPro.IP.Location;
using Volo.Abp.SecurityLog;

namespace RuiChen.AbpPro.AuditLogging.Location
{
    public class IPLocationSecurityLogStore : SecurityLogStore
    {
        private readonly AbpAuditLoggingIPLocationOptions _options;
        private readonly IIPLocationResolver _iPLocationResolver;
        public IPLocationSecurityLogStore(
            IOptionsMonitor<AbpAuditLoggingIPLocationOptions> options,
            IIPLocationResolver iPLocationResolver,
            ISecurityLogManager manager)
            : base(manager)
        {
            _options = options.CurrentValue;
            _iPLocationResolver = iPLocationResolver;
        }

        public async override Task SaveAsync(SecurityLogInfo securityLogInfo)
        {
            if (_options.IsEnabled && !securityLogInfo.ClientIpAddress.IsNullOrWhiteSpace())
            {
                var result = await _iPLocationResolver.ResolveAsync(securityLogInfo.ClientIpAddress);

                if (result.Location?.Remarks?.IsNullOrWhiteSpace() == false)
                {
                    securityLogInfo.ExtraProperties.Add("Location", $"{result.Location.Remarks}");
                }
            }

            await base.SaveAsync(securityLogInfo);
        }
    }
}
