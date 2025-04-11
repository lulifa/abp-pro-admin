using System.Web;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.Features;

namespace RuiChen.AbpPro.OssManagement
{
    public class StaticFilesAppService : OssManagementApplicationServiceBase, IStaticFilesAppService
    {
        protected IOssContainerFactory OssContainerFactory { get; }

        public StaticFilesAppService(
            IOssContainerFactory ossContainerFactory)
        {
            OssContainerFactory = ossContainerFactory;
        }

        [RequiresFeature(AbpOssManagementFeatureNames.OssObject.DownloadFile)]
        public async virtual Task<IRemoteStreamContent> GetAsync(GetStaticFileInput input)
        {
            var ossObjectRequest = new GetOssObjectRequest(
                HttpUtility.UrlDecode(input.Bucket), // 需要处理特殊字符
                HttpUtility.UrlDecode(input.Name),
                HttpUtility.UrlDecode(input.Path),
                HttpUtility.UrlDecode(input.Process))
            {
                MD5 = true,
            };

            var ossContainer = OssContainerFactory.Create();
            var ossObject = await ossContainer.GetObjectAsync(ossObjectRequest);
            if (ossObject == null || ossObject.Content.IsNullOrEmpty())
            {
                throw new BusinessException(code: OssManagementErrorCodes.ObjectNotFound);
            }

            return new RemoteStreamContent(ossObject.Content, ossObject.Name);
        }
    }
}
