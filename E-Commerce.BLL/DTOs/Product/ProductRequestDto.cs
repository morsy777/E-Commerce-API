using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce.BLL.DTOs.Product;

public class ProductRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Precision(18, 2)]
    public decimal Price { get; set; }
    public IFormFile Image { get; set; } = default!;
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
}
