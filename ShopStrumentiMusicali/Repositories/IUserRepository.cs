using Microsoft.AspNetCore.Identity;

namespace ShopStrumentiMusicali.Repositories
{
    public interface IUserRepository
    {
        ICollection<IdentityUser> GetUsers();
    }
}
