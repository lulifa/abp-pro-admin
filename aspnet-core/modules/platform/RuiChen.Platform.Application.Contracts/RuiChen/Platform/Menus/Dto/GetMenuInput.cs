using Volo.Abp.Validation;

namespace RuiChen.Platform
{
    public class GetMenuInput
    {
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
