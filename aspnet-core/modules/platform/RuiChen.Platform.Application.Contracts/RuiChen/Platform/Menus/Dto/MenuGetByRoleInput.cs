using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class MenuGetByRoleInput
    {
        [Required]
        [StringLength(80)]
        public string Role { get; set; }

        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
