namespace ShopStrumentiMusicali.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWork(IUserRepository user,IRoleRepository role)
        {
             User = user;
             Role= role;
        }

    }
}
