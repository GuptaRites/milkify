using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using milkify.Areas.Identity.Data;

namespace milkify.Areas.Identity.Data
{
    public class MilkifyContext : IdentityDbContext<MilkifyUser>
    {
        public MilkifyContext(DbContextOptions<MilkifyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppEntityConfig());
        }
    }

    public class AppEntityConfig : IEntityTypeConfiguration<MilkifyUser>
    {
        public void Configure(EntityTypeBuilder<MilkifyUser> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(256);
            builder.Property(x => x.Gender).HasMaxLength(10);
        }
    }
}
