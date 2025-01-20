using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Account
{
    [Route("api/account")]
    public class AccountController : AccountControllerBase, IAccountAppService
    {
        private readonly IAccountAppService accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            this.accountAppService = accountAppService;
        }

        [HttpPost]
        [Route("phone/register")]
        public async virtual Task RegisterPhoneAsync(PhoneRegisterDto input)
        {
            await accountAppService.RegisterPhoneAsync(input);
        }

        [HttpPut]
        [Route("phone/reset-password")]
        public async virtual Task ResetPasswordAsync(PhoneResetPasswordDto input)
        {
            await accountAppService.ResetPasswordAsync(input);
        }

        [HttpPost]
        [Route("phone/send-signin-code")]
        public async virtual Task SendPhoneSigninCodeAsync(SendPhoneSigninCodeDto input)
        {
            await accountAppService.SendPhoneSigninCodeAsync(input);
        }

        [HttpPost]
        [Route("email/send-signin-code")]
        public async virtual Task SendEmailSigninCodeAsync(SendEmailSigninCodeDto input)
        {
            await accountAppService.SendEmailSigninCodeAsync(input);
        }

        [HttpPost]
        [Route("phone/send-register-code")]
        public async virtual Task SendPhoneRegisterCodeAsync(SendPhoneRegisterCodeDto input)
        {
            await accountAppService.SendPhoneRegisterCodeAsync(input);
        }

        [HttpPost]
        [Route("phone/send-password-reset-code")]
        public async virtual Task SendPhoneResetPasswordCodeAsync(SendPhoneResetPasswordCodeDto input)
        {
            await accountAppService.SendPhoneResetPasswordCodeAsync(input);
        }

        [HttpGet]
        [Route("two-factor-providers")]
        public async virtual Task<ListResultDto<NameValue>> GetTwoFactorProvidersAsync(GetTwoFactorProvidersInput input)
        {
            return await accountAppService.GetTwoFactorProvidersAsync(input);
        }

    }
}
