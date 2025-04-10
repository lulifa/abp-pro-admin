namespace RuiChen.AbpPro.OssManagement
{
    public interface IFileUploader
    {
        Task UploadAsync(UploadFileChunkInput input, CancellationToken cancellationToken = default);
    }
}
