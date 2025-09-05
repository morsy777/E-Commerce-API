using E_Commerce.BLL.DTOs.Product;
using E_Commerce.BLL.DTOs.ShoppingCart;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace E_Commerce.BLL.Services;

public class ShoppingCartService(AppDbContext context) : IShoppingCartService
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddProductToCartAsync(string userId, int productId, int quantity,
        CancellationToken cancellationToken = default)
    {
        if (!_context.Products.Any(p => p.ProductId == productId))
            return false;

        var shoppingCart = await _context.ShoppingCarts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        if (shoppingCart is null)
        {
            shoppingCart = new ShoppingCart()
            {
                UserId = userId,
                CartItems = new List<CartItem>()
            };

            _context.ShoppingCarts.Add(shoppingCart);
        }

        var existingCartProduct = shoppingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        if (existingCartProduct is not null)
        {
            existingCartProduct.Quantity += quantity;
        }
        else
        {
            var newCartProduct = new CartItem()
            {
                ProductId = productId,
                Quantity = quantity,
            };

            shoppingCart.CartItems.Add(newCartProduct);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<CartResponseDto>> GetProductCartByUserId(string userId, CancellationToken cancellationToken = default)
    {
        var cart = await _context.ShoppingCarts
              .Where(c => c.UserId == userId)
              .Select(c => new CartResponseDto
              {
                  CartId = c.CartId,
                  UserId = c.UserId,
                  Items = c.CartItems.Select(ci => new CartProductDto
                  {
                      ProductId = ci.ProductId,
                      Title = ci.Product.Title,
                      Description = ci.Product.Description,
                      Price = ci.Product.Price,
                      Image = ci.Product.Image != null ? Convert.ToBase64String(ci.Product.Image) : string.Empty,
                      Quantity = ci.Quantity,
                      Total = ci.Quantity * ci.Product.Price,
                  }).ToList(),

                  TotalAmount = c.CartItems.Sum(ci => ci.Quantity * ci.Product.Price)
              })
              .ToListAsync(cancellationToken);

        return cart;
    }

    public async Task<bool> RemoveProductCartByProductId(string userId, int productId, CancellationToken cancellationToken = default)
    {
        var isExist = await _context.Products.AnyAsync(p => p.ProductId == productId);

        if (!isExist)
            return false;

        var cart = await _context.ShoppingCarts
            .Include(s => s.CartItems)
            .FirstOrDefaultAsync(s => s.UserId == userId);

        if (cart is null)
            return false;

        var cartProduct = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        if (cartProduct is null) 
            return false;

        _context.CartItems.Remove(cartProduct);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    } 
}
