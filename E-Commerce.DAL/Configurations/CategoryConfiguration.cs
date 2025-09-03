using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);

           
            builder.HasData(
                new Category { CategoryId = 1, Title = "Electronics", Prefix = "Electronic devices" },
                new Category { CategoryId = 2, Title = "Accessories", Prefix = "Tech accessories" },
                new Category { CategoryId = 3, Title = "Furniture", Prefix = "Home and office furniture" },
                new Category { CategoryId = 4, Title = "Books", Prefix = "Educational and entertainment books" },
                new Category { CategoryId = 5, Title = "Clothing", Prefix = "Apparel and fashion" }
            );
        }
    }
}
