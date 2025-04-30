using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    public interface IIdentitySessionRepository : Volo.Abp.Identity.IIdentitySessionRepository
    {

        Task<IdentitySession> FindLastAsync(
        Guid userId,
        string device = null,
        CancellationToken cancellationToken = default);

        Task<List<IdentitySession>> GetListAsync(
            Guid userId,
            string device,
            Guid? exceptSessionId = null,
            int maxResultCount = 0,
            CancellationToken cancellationToken = default);

        Task<List<IdentitySession>> GetListAsync(Guid userId, CancellationToken cancellationToken = default);

        Task DeleteAllSessionAsync(string sessionId, Guid? exceptSessionId = null, CancellationToken cancellationToken = default);

    }
}
