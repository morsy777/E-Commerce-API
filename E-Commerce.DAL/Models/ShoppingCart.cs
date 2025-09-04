namespace E_Commerce.DAL.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;

        public ICollection<CartItem> CartItems { get; set; }  = new List<CartItem>();   
    }
}
