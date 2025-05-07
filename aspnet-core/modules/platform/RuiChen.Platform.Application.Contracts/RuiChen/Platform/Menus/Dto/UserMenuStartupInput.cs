using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class UserMenuStartupInput
    {
        public Guid UserId { get; set; }


        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
