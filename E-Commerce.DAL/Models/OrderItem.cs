using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
