using AutoMapper;
using E_Commerce.BLL.DTOs.Order;
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

public class OrderService(AppDbContext context) : IOrderService
{
    private readonly AppDbContext _context = context;
    private readonly string _orderStatus = "Pending";

    // Place to Order in Front
    public async Task<bool> CheckoutAsync(string userId, CancellationToken cancellationToken)
    {
        var cart = await _context.ShoppingCarts
            .Include(s => s.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);

        if(cart is null || !cart.CartItems.Any())
            return false;

        var totalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price);

        var newOrder = new Order 
        { 
            UserId = userId,
            Status = _orderStatus,
            OrderDate = DateTime.UtcNow,
            TotalAmount = totalAmount,

            OrderItems = cart.CartItems.Select(ci => new OrderItem
            { 
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product.Price
            }).ToList()
        };

        await _context.Orders.AddAsync(newOrder);

        _context.CartItems.RemoveRange(cart.CartItems);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    // Details button in Order Page
    public async Task<IEnumerable<OrderProductDetailsResponseDto>> GetOrderProductsDetailsAsync(string userId, int orderId, CancellationToken cancellationToken)
    {
        var orderProductsDetails = await _context.Orders
            .Where(o => o.UserId == userId && o.OrderId == orderId)
            .SelectMany(o => o.OrderItems.Select(oi => new OrderProductDetailsResponseDto 
            {
                ProductTitle = oi.Product.Title,
                ProductImage = oi.Product.Image != null? Convert.ToBase64String(oi.Product.Image) : string.Empty,
                ProductPrice = oi.Product.Price,

                ProductQuantityInOrderItems = oi.Quantity,

                TotalAmountForeachProduct = oi.Product.Price * oi.Quantity
            }))
            .ToListAsync(); 

        return orderProductsDetails;
    }

    public async Task<IEnumerable<UserOrderResponseDto>> GetUserOrdersAsync(string userId, CancellationToken cancellationToken)
    {
        var userOrders = await _context.Orders
            .Where(o => o.UserId == userId)
            .Select(o => new UserOrderResponseDto
            {
                CountOfItems = o.OrderItems.Count(),
                TotalAmoutForeachOrder = o.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity),
            })
            .ToListAsync(cancellationToken);

        return userOrders;
    }

    public async Task<bool> RemoveUserOrderAsync(string userId, int orderId, CancellationToken cancellationToken)
    {
        var userOrder = await _context.Orders
            .FirstOrDefaultAsync(o => o.UserId == userId && o.OrderId == orderId);

        if (userOrder is null)
            return false;

        _context.Orders.Remove(userOrder);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> RemoveUserAllOrdersAsync(string userId, CancellationToken cancellationToken)
    {
        var userOrders = _context.Orders
            .Where(o => o.UserId == userId);

        if (!userOrders.Any()) 
            return false;

        _context.Orders.RemoveRange(userOrders);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

}