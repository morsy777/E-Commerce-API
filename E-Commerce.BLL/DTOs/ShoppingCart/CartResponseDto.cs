using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.ShoppingCart;
public class CartResponseDto
{
    public int CartId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public List<CartProductDto> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
}
