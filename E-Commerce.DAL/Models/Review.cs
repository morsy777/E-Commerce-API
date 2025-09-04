namespace E_Commerce.DAL.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }  = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
