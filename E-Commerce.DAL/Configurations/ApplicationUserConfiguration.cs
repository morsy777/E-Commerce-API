using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(u => u.ShoppingCart)       
                   .WithOne(c => c.User)
                   .HasForeignKey<ShoppingCart>(c => c.UserId);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId);

            builder.HasMany(u => u.Reviews)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId);

            builder.HasData(
                new ApplicationUser { UserId = 1, FirstName = "Alice", LastName = "Smith" },
                new ApplicationUser { UserId = 2, FirstName = "Bob", LastName = "Johnson" },
                new ApplicationUser { UserId = 3, FirstName = "Charlie", LastName = "Brown" },
                new ApplicationUser { UserId = 4, FirstName = "Diana", LastName = "Wilson" },
                new ApplicationUser { UserId = 5, FirstName = "Ethan", LastName = "Taylor" }
            );
        }
    }
}
