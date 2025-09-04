using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.Status).IsRequired();

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);


            builder.HasData(
    new Order { OrderId = 1, UserId = 1, OrderDate = new DateTime(2025, 9, 1), TotalAmount = 250, Status = "Completed" },
    new Order { OrderId = 2, UserId = 2, OrderDate = new DateTime(2025, 9, 2), TotalAmount = 120, Status = "Pending" },
    new Order { OrderId = 3, UserId = 3, OrderDate = new DateTime(2025, 9, 3), TotalAmount = 350, Status = "Shipped" },
    new Order { OrderId = 4, UserId = 4, OrderDate = new DateTime(2025, 9, 4), TotalAmount = 90, Status = "Cancelled" },
    new Order { OrderId = 5, UserId = 5, OrderDate = new DateTime(2025, 9, 5), TotalAmount = 500, Status = "Processing" }
);
        }
    }
}
