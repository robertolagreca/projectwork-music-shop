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

        public IdentityUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<IdentityUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IdentityUser UpdateUser(IdentityUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
