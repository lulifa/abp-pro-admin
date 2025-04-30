namespace RuiChen.AbpPro.Identity
{
    public class AbpIdentitySessionAspNetCoreOptions
    {
        public AbpIdentitySessionAspNetCoreOptions()
        {
            IsParseIpLocation = false;
        }

        /// <summary>
        /// 是否解析IP地理信息
        /// </summary>
        public bool IsParseIpLocation { get; set; }
    }
}
