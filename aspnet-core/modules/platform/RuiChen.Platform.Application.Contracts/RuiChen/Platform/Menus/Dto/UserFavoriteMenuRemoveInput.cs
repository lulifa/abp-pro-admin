using System.ComponentModel.DataAnnotations;

namespace RuiChen.Platform
{
    public class UserFavoriteMenuRemoveInput
    {
        [Required]
        public Guid MenuId { get; set; }
    }
}
