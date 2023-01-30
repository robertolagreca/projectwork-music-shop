using Microsoft.AspNetCore.Identity;
using ShopStrumentiMusicali.Database;

namespace ShopStrumentiMusicali.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ParamusicContext _context;
      
        public UserRepository(ParamusicContext context)
        {
            _context = context;
        }



public ICollection<IdentityUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
