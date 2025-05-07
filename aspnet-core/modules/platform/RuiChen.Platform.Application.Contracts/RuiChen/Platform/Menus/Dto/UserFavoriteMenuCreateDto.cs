using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace RuiChen.Platform
{

    public class UserFavoriteMenuCreateDto : UserFavoriteMenuCreateOrUpdateDto
    {
        [Required]
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]

        public string Framework { get; set; }
    }
}
