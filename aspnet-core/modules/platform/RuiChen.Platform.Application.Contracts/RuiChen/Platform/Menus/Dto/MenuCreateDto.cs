using System.ComponentModel.DataAnnotations;

namespace RuiChen.Platform
{
    public class MenuCreateDto : MenuCreateOrUpdateDto
    {
        [Required]
        public Guid LayoutId { get; set; }
    }
}
