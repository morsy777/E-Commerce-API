using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace E_Commerce.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = default!;

        
        public ICollection<OrderItem> OrderItems { get; set; }  = new List<OrderItem>();    
    }
}
