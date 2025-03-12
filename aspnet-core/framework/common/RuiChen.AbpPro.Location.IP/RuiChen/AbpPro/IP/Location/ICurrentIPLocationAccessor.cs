namespace RuiChen.AbpPro.IP.Location
{
    public interface ICurrentIPLocationAccessor
    {
        IPLocation? Current { get; set; }
    }
}
