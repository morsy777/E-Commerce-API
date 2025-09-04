using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Product;
public class ProductResponseDto
{
    public int ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Image { get; set; } 
    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty; 
}