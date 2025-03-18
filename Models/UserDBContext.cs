using Microsoft.EntityFrameworkCore;

namespace milkify.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<MilkCollection> MilkCollections { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
