using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

           
            builder.HasData(
                new Product { ProductId = 1, Title = "Laptop", Description = "Gaming laptop", Price = 1000, ImageUrl = "laptop.jpg", StockQuantity = 10, CategoryId = 1 },
                new Product { ProductId = 2, Title = "Phone", Description = "Smartphone", Price = 500, ImageUrl = "phone.jpg", StockQuantity = 20, CategoryId = 1 },
                new Product { ProductId = 3, Title = "Headphones", Description = "Wireless headphones", Price = 150, ImageUrl = "headphones.jpg", StockQuantity = 50, CategoryId = 2 },
                new Product { ProductId = 4, Title = "Chair", Description = "Office chair", Price = 200, ImageUrl = "chair.jpg", StockQuantity = 30, CategoryId = 3 },
                new Product { ProductId = 5, Title = "Desk", Description = "Wooden desk", Price = 300, ImageUrl = "desk.jpg", StockQuantity = 15, CategoryId = 3 }
            );
        }
    }
}
