using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Database
{
    public class ParamusicContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }
        public DbSet<ShopTransaction> ShopTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=ParamusicDB;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
