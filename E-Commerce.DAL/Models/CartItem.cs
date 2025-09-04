namespace E_Commerce.DAL.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; } = default!;

        public int ProductId { get; set; } 
        public Product Product { get; set; } = default!;
    }
}
