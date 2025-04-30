using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace RuiChen.AbpPro.Identity
{
    [Dependency(ServiceLifetime.Singleton, TryRegister = true)]
    public class DefaultSessionInfoProvider : ISessionInfoProvider
    {
        private readonly AsyncLocal<string> _currentSessionId = new AsyncLocal<string>();

        public string SessionId => _currentSessionId.Value;

        public virtual IDisposable Change(string sessionId)
        {
            var parent = SessionId;
            _currentSessionId.Value = sessionId;
            return new DisposeAction(() =>
            {
                _currentSessionId.Value = parent;
            });

        }
    }
}
