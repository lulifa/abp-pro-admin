using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class UserFavoriteMenuGetListInput
    {
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
