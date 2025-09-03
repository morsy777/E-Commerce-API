using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(c => c.CartId);

            builder.HasOne(c => c.User)              
                   .WithOne(u => u.ShoppingCart)
                   .HasForeignKey<ShoppingCart>(c => c.UserId);

            builder.HasData(
                new ShoppingCart { CartId = 1, UserId = 1 },
                new ShoppingCart { CartId = 2, UserId = 2 },
                new ShoppingCart { CartId = 3, UserId = 3 },
                new ShoppingCart { CartId = 4, UserId = 4 },
                new ShoppingCart { CartId = 5, UserId = 5 }
            );
        }
    }
}
