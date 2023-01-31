using Microsoft.AspNetCore.Identity;

namespace ShopStrumentiMusicali.Repositories
{
    public interface IUserRepository
    {
       public ICollection<IdentityUser> GetUsers();
       public IdentityUser GetUser(string id);
        public IdentityUser UpdateUser(IdentityUser user);
    }
}
