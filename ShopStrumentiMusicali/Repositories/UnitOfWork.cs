namespace ShopStrumentiMusicali.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        public IUserRepository User { get; }

        public UnitOfWork(IUserRepository user)
        {
             User = user;
        }

    }
}
