using Volo.Abp.EventBus;

namespace RuiChen.Platform
{
    [EventName("platform.menus.menu")]
    public class MenuEto : RouteEto
    {
        public string Framework { get; set; }
    }
}
