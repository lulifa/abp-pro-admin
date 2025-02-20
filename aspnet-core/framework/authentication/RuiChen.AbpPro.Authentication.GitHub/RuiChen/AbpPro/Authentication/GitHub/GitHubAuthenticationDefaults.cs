namespace RuiChen.AbpPro.Authentication.GitHub;

public class GitHubAuthenticationDefaults
{
    public const string AuthenticationScheme = "GitHub";

    public static readonly string DisplayName = "GitHub";

    public static readonly string Issuer = "GitHub";

    public static readonly string CallbackPath = "/signin-github";

    public static readonly string AuthorizationEndpoint = "https://github.com/login/oauth/authorize";

    public static readonly string TokenEndpoint = "https://github.com/login/oauth/access_token";

    public static readonly string UserInformationEndpoint = "https://api.github.com/user";

    public static readonly string UserEmailsEndpoint = "https://api.github.com/user/emails";

}
