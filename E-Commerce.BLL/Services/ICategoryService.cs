using E_Commerce.BLL.DTOs.Category;
using E_Commerce.BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    Task<CategoryResponseDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CategoryResponseDto> AddAsync(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
