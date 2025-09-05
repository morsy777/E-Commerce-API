using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.ShoppingCart;
public class CartProductDto
{
    public int ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}
