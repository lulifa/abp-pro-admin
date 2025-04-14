using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.OssManagement
{
    public class GetOssObjectsInput : PagedAndSortedResultRequestDto
    {
        [Required]
        public string Bucket { get; set; }
        public string Prefix { get; set; }
        public string Delimiter { get; set; }
        public string Marker { get; set; }
        public string EncodingType { get; set; }
        public bool MD5 { get; set; }
    }
}
