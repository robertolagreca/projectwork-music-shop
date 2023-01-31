using Microsoft.AspNetCore.Identity;
using ShopStrumentiMusicali.Database;

namespace ShopStrumentiMusicali.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ParamusicContext _context;

        public RoleRepository(ParamusicContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList<IdentityRole>();
        }
    }
}
