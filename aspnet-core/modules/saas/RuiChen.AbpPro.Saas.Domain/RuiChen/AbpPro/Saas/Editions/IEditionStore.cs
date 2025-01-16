namespace RuiChen.AbpPro.Saas
{
    public interface IEditionStore
    {
        Task<EditionInfo> FindByTenantAsync(Guid tenantId);
    }
}
