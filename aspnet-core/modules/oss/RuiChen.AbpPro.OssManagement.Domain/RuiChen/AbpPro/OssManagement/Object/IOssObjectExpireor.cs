namespace RuiChen.AbpPro.OssManagement
{
    public interface IOssObjectExpireor
    {
        Task ExpireAsync(ExprieOssObjectRequest request);
    }
}
