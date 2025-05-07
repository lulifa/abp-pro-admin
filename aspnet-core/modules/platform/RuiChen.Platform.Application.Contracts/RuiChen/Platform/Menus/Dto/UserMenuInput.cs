using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class UserMenuInput
    {
        [Required]
        public Guid UserId { get; set; }


        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }

        public Guid? StartupMenuId { get; set; }

        [Required]
        public List<Guid> MenuIds { get; set; } = new List<Guid>();
    }
}
