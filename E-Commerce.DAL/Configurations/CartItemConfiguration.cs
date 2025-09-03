using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.CartItemId);

            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId);

            
            builder.HasData(
                new CartItem { CartItemId = 1, CartId = 1, ProductId = 1, Quantity = 1 },
                new CartItem { CartItemId = 2, CartId = 2, ProductId = 2, Quantity = 2 },
                new CartItem { CartItemId = 3, CartId = 3, ProductId = 3, Quantity = 3 },
                new CartItem { CartItemId = 4, CartId = 4, ProductId = 4, Quantity = 1 },
                new CartItem { CartItemId = 5, CartId = 5, ProductId = 5, Quantity = 4 }
            );
        }
    }
}
