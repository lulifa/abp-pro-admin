using Volo.Abp.EventBus;
using Volo.Abp.MultiTenancy;

namespace RuiChen.AbpPro.Identity
{
    [EventName("abp.identity.session.change_accessed")]
    public class IdentitySessionChangeAccessedEvent : IMultiTenant
    {
        public IdentitySessionChangeAccessedEvent()
        {

        }

        public IdentitySessionChangeAccessedEvent(
            string sessionId,
            string ipAddresses,
            DateTime lastAccessed,
            Guid? tenantId = null)
        {
            SessionId = sessionId;
            IpAddresses = ipAddresses;
            LastAccessed = lastAccessed;
            TenantId = tenantId;
        }

        public Guid? TenantId { get; set; }
        public string SessionId { get; set; }
        public string IpAddresses { get; set; }
        public DateTime LastAccessed { get; set; }

    }
}
