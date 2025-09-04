using Microsoft.AspNetCore.Identity;

namespace E_Commerce.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public ShoppingCart ShoppingCart { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } =  new List<Review>();
    }
}
