using Volo.Abp.Domain.Entities;

namespace RuiChen.Platform
{
    public class UserFavoriteMenuUpdateDto : UserFavoriteMenuCreateOrUpdateDto, IHasConcurrencyStamp
    {

        public string ConcurrencyStamp { get; set; }
    }
}
