using AutoMapper;
using E_Commerce.BLL.DTOs.Orders;
using E_Commerce.BLL.DTOs.Product;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public class OrderService(AppDbContext context, IMapper mapper) : IOrderService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var orders = await _context.Orders
              .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync(cancellationToken); // If there is no orders then ToList will return empty list, 

        return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
    }

    public Task<OrderResponseDto?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OrderResponseDto> AddAsync(int userId, OrderRequestDto orderRequestDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrdersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
