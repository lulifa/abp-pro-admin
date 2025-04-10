﻿using JetBrains.Annotations;
using Volo.Abp;

namespace RuiChen.AbpPro.OssManagement
{
    public class BulkDeleteObjectRequest
    {
        public string Bucket { get; }
        public string Path { get; }
        public ICollection<string> Objects { get; }

        public BulkDeleteObjectRequest(
            [NotNull] string bucket,
            ICollection<string> objects,
            string path = "")
        {
            Check.NotNullOrWhiteSpace(bucket, nameof(bucket));
            Check.NotNullOrEmpty(objects, nameof(objects));

            Bucket = bucket;
            Objects = objects;
            Path = path;
        }
    }
}
