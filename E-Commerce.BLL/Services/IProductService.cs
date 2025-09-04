using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetProductsAsync(CancellationToken cancellationToken = default);
    Task<ProductResponseDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductResponseDto>?> SearchByNameAsync(string title, CancellationToken cancellationToken = default);
    Task<ProductResponseDto> AddAsync(ProductRequestDto productDto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, ProductRequestDto product, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
