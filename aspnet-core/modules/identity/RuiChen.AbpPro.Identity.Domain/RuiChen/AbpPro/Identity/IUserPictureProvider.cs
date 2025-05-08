using Volo.Abp.Identity;

namespace RuiChen.AbpPro.Identity
{
    public interface IUserPictureProvider
    {
        Task SetPictureAsync(IdentityUser user, Stream stream, string fileName = null);

        Task<Stream> GetPictureAsync(string userId);
    }
}
