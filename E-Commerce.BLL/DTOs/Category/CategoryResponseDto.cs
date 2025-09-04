using E_Commerce.BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Category;
public class CategoryResponseDto
{
    public int CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public string? ImageData { get; set; }

    public List<ProductResponseDto> relatedProducts { get; set; } = new();
}
