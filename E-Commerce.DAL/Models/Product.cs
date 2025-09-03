namespace WebApplication3.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }= string.Empty;
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } =  new List<CartItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
