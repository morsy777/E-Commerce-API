using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.DAL.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.ReviewId);

            builder.Property(r => r.Comment).HasMaxLength(500);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.ProductId);

           
            //builder.HasData(
            //    new Review { ReviewId = 1, UserId = 1, ProductId = 1, Rating = 5, Comment = "Excellent product!" },
            //    new Review { ReviewId = 2, UserId = 2, ProductId = 2, Rating = 4, Comment = "Good value." },
            //    new Review { ReviewId = 3, UserId = 3, ProductId = 3, Rating = 3, Comment = "Average quality." },
            //    new Review { ReviewId = 4, UserId = 4, ProductId = 4, Rating = 5, Comment = "Very comfortable." },
            //    new Review { ReviewId = 5, UserId = 5, ProductId = 5, Rating = 4, Comment = "Well built desk." }
            //);
        }
    }
}
