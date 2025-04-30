namespace RuiChen.AbpPro.Openiddict
{
    public class AbpOpenIddictAspNetCoreSessionOptions
    {
        public AbpOpenIddictAspNetCoreSessionOptions()
        {
            PersistentSessionGrantTypes = new List<string>();
        }

        public List<string> PersistentSessionGrantTypes { get; set; }

    }
}
