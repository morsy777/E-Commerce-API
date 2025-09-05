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

public class OrderService(AppDbContext context) : IOrderService
{
    private readonly AppDbContext _context = context;
    private readonly string _orderStatus = "Pending";

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
}
