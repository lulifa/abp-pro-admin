namespace RuiChen.AbpPro.OssManagement
{
    public class NoneOssObjectProcesser : IOssObjectProcesserContributor
    {
        public Task ProcessAsync(OssObjectProcesserContext context)
        {
            context.SetContent(context.OssObject.Content);

            return Task.CompletedTask;
        }
    }
}
