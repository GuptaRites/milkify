using Microsoft.EntityFrameworkCore;

namespace milkify.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserRegister> Users { get; set; }
    }
}
