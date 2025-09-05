using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication3.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemId);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(oi => oi.ProductId);

            /*
            builder.HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 50 },
                new OrderItem { OrderItemId = 2, OrderId = 2, ProductId = 2, Quantity = 1, UnitPrice = 120 },
                new OrderItem { OrderItemId = 3, OrderId = 3, ProductId = 3, Quantity = 3, UnitPrice = 100 },
                new OrderItem { OrderItemId = 4, OrderId = 4, ProductId = 4, Quantity = 1, UnitPrice = 90 },
                new OrderItem { OrderItemId = 5, OrderId = 5, ProductId = 5, Quantity = 5, UnitPrice = 100 }
            );*/
        }
    }
}
