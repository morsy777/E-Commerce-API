namespace E_Commerce.DAL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;

        public byte[]? ImageData { get; set; } 


        public ICollection<Product> Products { get; set; }  = new List<Product>();
    }
}
