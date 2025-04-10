namespace RuiChen.AbpPro.OssManagement
{
    public interface IOssObjectProcesserContributor
    {
        Task ProcessAsync(OssObjectProcesserContext context);
    }
}
