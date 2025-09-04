using AutoMapper;
using Azure.Core;
using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;
public class ProductService(IMapper mapper, AppDbContext context) : IProductService
{
    private readonly IMapper _mapper = mapper;
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
    public async Task<ProductResponseDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.ProductId == id);

        return product is null ? null : _mapper.Map<ProductResponseDto>(product);   
    }

    public async Task<ProductResponseDto> AddAsync(ProductRequestDto productDto, CancellationToken cancellationToken = default)
    {
        var product = _mapper.Map<Product>(productDto);

        if (productDto.Image != null)
        {
            using var ms = new MemoryStream();
            await productDto.Image.CopyToAsync(ms);
            product.Image = ms.ToArray();
        }

        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _context.Entry(product).Reference(p => p.Category).LoadAsync(cancellationToken);

        return _mapper.Map<ProductResponseDto>(product);
    }
    
    public async Task<bool> UpdateAsync(int id, ProductRequestDto productDto, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FindAsync(id, cancellationToken);

        if (product is null)
            return false;

        _mapper.Map(productDto, product);

        if (productDto.Image != null)
        {
            using var ms = new MemoryStream();
            await productDto.Image.CopyToAsync(ms, cancellationToken);
            product.Image = ms.ToArray();
        }

        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FindAsync(id, cancellationToken);
        if (product is null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
    
    public async Task<IEnumerable<ProductResponseDto>?> SearchByNameAsync(string title, CancellationToken cancellationToken = default)
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Title.Contains(title.ToLower()))
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }

}
