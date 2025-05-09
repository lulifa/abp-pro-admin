﻿using Microsoft.AspNetCore.Authorization;
using System.Web;
using Volo.Abp.Content;

namespace RuiChen.AbpPro.OssManagement
{
    [Authorize(AbpOssManagementPermissions.OssObject.Default)]
    public class OssObjectAppService : OssManagementApplicationServiceBase, IOssObjectAppService
    {
        protected FileUploadMerger Merger { get; }
        protected IOssContainerFactory OssContainerFactory { get; }

        public OssObjectAppService(
            FileUploadMerger merger,
            IOssContainerFactory ossContainerFactory)
        {
            Merger = merger;
            OssContainerFactory = ossContainerFactory;
        }

        [Authorize(AbpOssManagementPermissions.OssObject.Create)]
        public async virtual Task<OssObjectDto> CreateAsync(CreateOssObjectInput input)
        {
            // 内容为空时建立目录
            if (input.File == null || !input.File.ContentLength.HasValue)
            {
                var oss = CreateOssContainer();
                var request = new CreateOssObjectRequest(
                    HttpUtility.UrlDecode(input.Bucket),
                    HttpUtility.UrlDecode(input.FileName),
                    Stream.Null,
                    HttpUtility.UrlDecode(input.Path));
                var ossObject = await oss.CreateObjectAsync(request);

                return ObjectMapper.Map<OssObject, OssObjectDto>(ossObject);
            }
            else
            {
                var ossObject = await Merger.MergeAsync(input);

                return ObjectMapper.Map<OssObject, OssObjectDto>(ossObject);
            }
        }

        [Authorize(AbpOssManagementPermissions.OssObject.Delete)]
        public async virtual Task BulkDeleteAsync(BulkDeleteOssObjectInput input)
        {
            var oss = CreateOssContainer();

            await oss.BulkDeleteObjectsAsync(input.Bucket, input.Objects, input.Path);
        }

        [Authorize(AbpOssManagementPermissions.OssObject.Delete)]
        public async virtual Task DeleteAsync(GetOssObjectInput input)
        {
            var oss = CreateOssContainer();

            await oss.DeleteObjectAsync(input.Bucket, input.Object, input.Path);
        }

        public async virtual Task<OssObjectDto> GetAsync(GetOssObjectInput input)
        {
            var oss = CreateOssContainer();

            var ossObject = await oss.GetObjectAsync(input.Bucket, input.Object, input.Path, input.MD5);

            return ObjectMapper.Map<OssObject, OssObjectDto>(ossObject);
        }

        public async virtual Task<IRemoteStreamContent> GetContentAsync(GetOssObjectInput input)
        {
            var oss = CreateOssContainer();

            var ossObject = await oss.GetObjectAsync(input.Bucket, input.Object, input.Path, input.MD5);

            return new RemoteStreamContent(ossObject.Content, ossObject.Name);
        }

        protected virtual IOssContainer CreateOssContainer()
        {
            return OssContainerFactory.Create();
        }
    }
}
