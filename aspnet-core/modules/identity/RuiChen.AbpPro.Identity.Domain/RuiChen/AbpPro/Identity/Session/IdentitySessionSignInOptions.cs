namespace RuiChen.AbpPro.Identity
{
    public class IdentitySessionSignInOptions
    {
        public IdentitySessionSignInOptions()
        {
            AuthenticationSchemes = new List<string>
            {
                "Identity.Application"
            };
        }

        /// <summary>
        /// 用于处理的身份认证方案
        /// </summary>
        public List<string> AuthenticationSchemes { get; set; }

        /// <summary>
        /// 是否启用SignInManager登录会话
        /// 默认：false
        /// </summary>
        public bool SignInSessionEnabled { get; set; }

        /// <summary>
        /// 是否启用SignOutManger登出会话
        /// 默认：false
        /// </summary>
        public bool SignOutSessionEnabled { get; set; }

    }
}
