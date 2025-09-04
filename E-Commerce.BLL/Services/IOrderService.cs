using E_Commerce.BLL.DTOs.Orders;
using E_Commerce.BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(CancellationToken cancellationToken = default);
    Task<OrderResponseDto?> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<OrderResponseDto> AddAsync(int userId, OrderRequestDto orderRequestDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> DeleteOrdersAsync(CancellationToken cancellationToken = default);
}
