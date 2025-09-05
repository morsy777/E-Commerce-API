namespace E_Commerce.DAL.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }

        public string UserId { get; set; } = string.Empty; // string
        public ApplicationUser User { get; set; } = default!;

        public ICollection<CartItem> CartItems { get; set; }  = new List<CartItem>();   
    }
}
