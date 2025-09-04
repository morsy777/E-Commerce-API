using AutoMapper;
using E_Commerce.BLL.DTOs.Category;
using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public class CategoryService(AppDbContext context, IMapper mapper) : ICategoryService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _context.Categories
            .Include(c => c.Products)
            .ToListAsync(cancellationToken);

        if(categories is null)
            return Enumerable.Empty<CategoryResponseDto>();

        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }


    public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.CategoryId == id, cancellationToken);

        return category is null ? null : _mapper.Map<CategoryResponseDto?>(category);
    }

    public async Task<CategoryResponseDto> AddAsync(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken = default)
    {
        var newCategory = _mapper.Map<Category>(categoryRequestDto);

        if(categoryRequestDto.ImageData is not null)
        {
            using var ms = new MemoryStream();
            await categoryRequestDto.ImageData.CopyToAsync(ms);
            newCategory.ImageData = ms.ToArray();
        }

        await _context.Categories.AddAsync(newCategory, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CategoryResponseDto>(newCategory);
    }

    public async Task<bool> UpdateAsync(int id, CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories.FindAsync(id, cancellationToken);

        if (category is null)
            return false;

        _mapper.Map(categoryRequestDto, category);

        if (categoryRequestDto.ImageData != null)
        {
            using var ms = new MemoryStream();
            await categoryRequestDto.ImageData.CopyToAsync(ms, cancellationToken);
            category.ImageData = ms.ToArray();
        }

        _context.Categories.Update(category);
        await _context.SaveChangesAsync(cancellationToken);

        await _context.Entry(category).Collection(p => p.Products).LoadAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories.FindAsync(id, cancellationToken);

        if (category is null)
            return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }


}
