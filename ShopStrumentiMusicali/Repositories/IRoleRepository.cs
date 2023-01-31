using Microsoft.AspNetCore.Identity;

namespace ShopStrumentiMusicali.Repositories
{
    public interface IRoleRepository
    {
        public ICollection<IdentityRole> GetRoles ();
    }
}
