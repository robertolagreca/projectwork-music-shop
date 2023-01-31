namespace ShopStrumentiMusicali.Repositories
{
    public interface IUnitofWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
    }
}
