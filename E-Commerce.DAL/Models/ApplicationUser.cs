namespace WebApplication3.Models
{
    public class ApplicationUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public ShoppingCart ShoppingCart { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } =  new List<Review>();
    }
}
