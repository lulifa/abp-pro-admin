using JetBrains.Annotations;

namespace RuiChen.AbpPro.IP.Location
{
    public interface IIPLocationResolver
    {
        [NotNull]
        Task<IPLocationResolveResult> ResolveAsync(string ipAddress);
    }
}
