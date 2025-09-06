using E_Commerce.BLL.DTOs.Order;
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
    Task<bool> CheckoutAsync(string userId, CancellationToken cancellationToken);
    Task<IEnumerable<OrderProductDetailsResponseDto>> GetOrderProductsDetailsAsync(string userId, int orderId, CancellationToken cancellationToken);
    Task<IEnumerable<UserOrderResponseDto>> GetUserOrdersAsync(string userId, CancellationToken cancellationToken);
    Task<bool> RemoveUserOrderAsync(string userId, int orderId, CancellationToken cancellationToken);
    Task<bool> RemoveUserAllOrdersAsync(string userId, CancellationToken cancellationToken);

}
