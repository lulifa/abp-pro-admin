﻿using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Account
{
    [Route("api/account")]
    public class AccountController : AccountControllerBase, IAccountAppService
    {
        protected IAccountAppService AccountAppService { get; }
        public AccountController(
            IAccountAppService accountAppService)
        {
            AccountAppService = accountAppService;
        }

        [HttpPost]
        [Route("phone/register")]
        public async virtual Task RegisterAsync(PhoneRegisterDto input)
        {
            await AccountAppService.RegisterAsync(input);
        }

        [HttpPut]
        [Route("phone/reset-password")]
        public async virtual Task ResetPasswordAsync(PhoneResetPasswordDto input)
        {
            await AccountAppService.ResetPasswordAsync(input);
        }

        [HttpPost]
        [Route("phone/send-signin-code")]
        public async virtual Task SendPhoneSigninCodeAsync(SendPhoneSigninCodeDto input)
        {
            await AccountAppService.SendPhoneSigninCodeAsync(input);
        }

        [HttpPost]
        [Route("email/send-signin-code")]
        public async virtual Task SendEmailSigninCodeAsync(SendEmailSigninCodeDto input)
        {
            await AccountAppService.SendEmailSigninCodeAsync(input);
        }

        [HttpPost]
        [Route("phone/send-register-code")]
        public async virtual Task SendPhoneRegisterCodeAsync(SendPhoneRegisterCodeDto input)
        {
            await AccountAppService.SendPhoneRegisterCodeAsync(input);
        }

        [HttpPost]
        [Route("phone/send-password-reset-code")]
        public async virtual Task SendPhoneResetPasswordCodeAsync(SendPhoneResetPasswordCodeDto input)
        {
            await AccountAppService.SendPhoneResetPasswordCodeAsync(input);
        }

        [HttpGet]
        [Route("two-factor-providers")]
        public async virtual Task<ListResultDto<NameValue>> GetTwoFactorProvidersAsync(GetTwoFactorProvidersInput input)
        {
            return await AccountAppService.GetTwoFactorProvidersAsync(input);
        }
    }
}
