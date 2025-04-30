namespace RuiChen.AbpPro.Identity
{
    public interface ISessionInfoProvider
    {
        string SessionId { get; }

        IDisposable Change(string sessionId);

    }
}
