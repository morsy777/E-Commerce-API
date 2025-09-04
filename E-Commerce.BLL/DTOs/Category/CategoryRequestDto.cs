using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs.Category;


public class CategoryRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Prefix { get; set; } = string.Empty;

    public IFormFile ImageData { get; set; } = default!;

}
