namespace RuiChen.AbpPro.Authentication.Gitee
{
    public static class GiteeAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Gitee";

        public static readonly string DisplayName = "Gitee";

        public static readonly string Issuer = "Gitee";

        public static readonly string CallbackPath = "/signin-gitee";

        public static readonly string AuthorizationEndpoint = "https://gitee.com/oauth/authorize";

        public static readonly string TokenEndpoint = "https://gitee.com/oauth/token";

        public static readonly string UserInformationEndpoint = "https://gitee.com/api/v5/user";

        public static readonly string UserEmailsEndpoint = "https://gitee.com/api/v5/emails";
    }
}
