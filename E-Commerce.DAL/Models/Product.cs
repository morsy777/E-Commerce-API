using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace E_Commerce.DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public byte[] Image { get; set; } = default!;
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } =  new List<CartItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
