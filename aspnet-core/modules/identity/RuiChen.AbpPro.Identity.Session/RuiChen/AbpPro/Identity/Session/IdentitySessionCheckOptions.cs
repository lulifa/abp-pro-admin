namespace RuiChen.AbpPro.Identity
{
    public class IdentitySessionCheckOptions
    {
        public IdentitySessionCheckOptions()
        {
            KeepAccessTimeSpan = TimeSpan.FromMinutes(1);

            SessionSyncTimeSpan = TimeSpan.FromMinutes(10);
        }

        /// <summary>
        /// 保持访问时长
        /// 默认：1分钟
        /// 刷新缓存会话间隔时长
        /// </summary>
        public TimeSpan KeepAccessTimeSpan { get; set; }


        /// <summary>
        /// 会话同步间隔（ms）
        /// 默认：10分钟
        /// 从缓存同步到持久化的间隔时长
        /// </summary>
        public TimeSpan SessionSyncTimeSpan { get; set; }


    }
}
