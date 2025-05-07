using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class DataItemCreateDto : DataItemCreateOrUpdateDto
    {
        [Required]
        [DynamicStringLength(typeof(DataItemConsts), nameof(DataItemConsts.MaxNameLength))]
        public string Name { get; set; }
    }
}
