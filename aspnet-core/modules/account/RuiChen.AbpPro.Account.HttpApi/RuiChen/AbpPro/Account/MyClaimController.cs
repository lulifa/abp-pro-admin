using Microsoft.AspNetCore.Mvc;

namespace RuiChen.AbpPro.Account
{
    [Route("/api/account/my-claim")]
    public class MyClaimController:AccountControllerBase, IMyClaimAppService
    {
        private readonly IMyClaimAppService myClaimAppService;

        public MyClaimController(IMyClaimAppService myClaimAppService)
        {
            this.myClaimAppService = myClaimAppService;
        }

        [HttpPost]
        [Route("change-avatar")]
        public async virtual Task ChangeAvatarAsync(ChangeAvatarInput input)
        {
            await myClaimAppService.ChangeAvatarAsync(input);
        }

    }
}
