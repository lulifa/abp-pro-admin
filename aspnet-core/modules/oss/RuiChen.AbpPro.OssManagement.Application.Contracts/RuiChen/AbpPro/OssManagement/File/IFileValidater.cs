namespace RuiChen.AbpPro.OssManagement
{
    public interface IFileValidater
    {
        Task ValidationAsync(UploadFile input);
    }
}
