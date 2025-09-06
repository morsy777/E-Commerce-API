using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Order;
public class OrderProductDetailsResponseDto
{
    public string ProductTitle { get; set; } = string.Empty;
    public string ProductImage { get; set; } = string.Empty;
    public int ProductQuantityInOrderItems { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal TotalAmountForeachProduct { get; set; }
}
