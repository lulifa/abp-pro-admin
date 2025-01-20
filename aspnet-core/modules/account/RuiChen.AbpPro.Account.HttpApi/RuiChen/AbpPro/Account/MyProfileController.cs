using Microsoft.AspNetCore.Mvc;

namespace RuiChen.AbpPro.Account
{
    [Route("/api/account/my-profile")]
    public class MyProfileController : AccountControllerBase, IMyProfileAppService
    {
        private readonly IMyProfileAppService myProfileAppService;

        public MyProfileController(IMyProfileAppService myProfileAppService)
        {
            this.myProfileAppService = myProfileAppService;
        }

        [HttpGet]
        [Route("two-factor")]
        public async virtual Task<TwoFactorEnabledDto> GetTwoFactorEnabledAsync()
        {
            return await myProfileAppService.GetTwoFactorEnabledAsync();
        }

        [HttpPut]
        [Route("change-two-factor")]
        public async virtual Task ChangeTwoFactorEnabledAsync(TwoFactorEnabledDto input)
        {
            await myProfileAppService.ChangeTwoFactorEnabledAsync(input);
        }

        [HttpPost]
        [Route("send-phone-number-change-code")]
        public async virtual Task SendChangePhoneNumberCodeAsync(SendChangePhoneNumberCodeInput input)
        {
            await myProfileAppService.SendChangePhoneNumberCodeAsync(input);
        }

        [HttpPut]
        [Route("change-phone-number")]
        public async virtual Task ChangePhoneNumberAsync(ChangePhoneNumberInput input)
        {
            await myProfileAppService.ChangePhoneNumberAsync(input);
        }

        [HttpPost]
        [Route("send-email-confirm-link")]
        public async virtual Task SendEmailConfirmLinkAsync(SendEmailConfirmCodeDto input)
        {
            await myProfileAppService.SendEmailConfirmLinkAsync(input);
        }

        [HttpPut]
        [Route("confirm-email")]
        public async virtual Task ConfirmEmailAsync(ConfirmEmailInput input)
        {
            await myProfileAppService.ConfirmEmailAsync(input);
        }

        [HttpGet]
        [Route("authenticator")]
        public async virtual Task<AuthenticatorDto> GetAuthenticator()
        {
            return await myProfileAppService.GetAuthenticator();
        }

        [HttpPost]
        [Route("verify-authenticator-code")]
        public async virtual Task<AuthenticatorRecoveryCodeDto> VerifyAuthenticatorCode(VerifyAuthenticatorCodeInput input)
        {
            return await myProfileAppService.VerifyAuthenticatorCode(input);
        }

        [HttpPost]
        [Route("reset-authenticator")]
        public async virtual Task ResetAuthenticator()
        {
            await myProfileAppService.ResetAuthenticator();
        }

    }
}
